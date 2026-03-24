using AutoMapper;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.OrderDTOs;
using LunchLine.Application.Exceptions.Commons;
using LunchLine.Domain.Entities.Workflow;
using LunchLine.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LunchLine.Persistence.Concretes.Services;

public class OrderService(AppDbContext _context, IMapper _mapper) : IOrderService
{
    public async Task<string> AddOrderAsync(OrderCreateDTO dto)
    {
        var order = _mapper.Map<Order>(dto);

        //UnitPrice = price of the MenuItem
        var menuItemIds = dto.OrderItems.Select(x => x.MenuItemId).ToList();
        if (!await _context.MenuItems.AnyAsync(x => menuItemIds.Contains(x.Id.ToString()))) throw new NotFoundException<MenuItem>();

        var menuItems = await _context.MenuItems.Where(x => menuItemIds.Contains(x.Id.ToString())).ToListAsync();
        foreach (var item in order.OrderItems)
            item.UnitPrice = menuItems.First(x => x.Id == item.MenuItemId).Price;

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order.Id.ToString();
    }

    public async Task ArchiveOrderByIdAsync(string id)
    {
        var order = await _getOrderAsync(id);
        order.IsArchived = !order.IsArchived;
        order.ArchivedAt = order.IsArchived ? DateTime.UtcNow : null;
        await _context.SaveChangesAsync();
    }

    public async Task<OrderGetDTO> GetOrderByIdAsync(string id)
    {
        return _mapper.Map<OrderGetDTO>(await _getOrderAsync(id));
    }

    public async Task<IEnumerable<OrderGetDTO>> GetOrdersAsync(GetListDTO dto)
    {
        var orders = await _context.Orders.Where(x => x.IsArchived == dto.IsArchived).Skip(dto.Skip).Take(dto.Take).Include(x => x.OrderItems).ThenInclude(x => x.MenuItem).ToListAsync();
        return _mapper.Map<IEnumerable<OrderGetDTO>>(orders);
    }

    public async Task RemoveOrderByIdAsync(string id)
    {
        await Task.Run(async () => _context.Orders.Remove(await _getOrderAsync(id)));
        await _context.SaveChangesAsync();
    }

    private async Task<Order> _getOrderAsync(string id)
    {
        var order = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.MenuItem).FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (order == null) throw new NotFoundException<Order>();
        return order;
    }
}