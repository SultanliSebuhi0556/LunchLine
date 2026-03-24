using AutoMapper;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.MenuItemDTOs;
using LunchLine.Application.Exceptions.Commons;
using LunchLine.Domain.Entities.Workflow;
using LunchLine.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LunchLine.Persistence.Concretes.Services;

public class MenuItemService(AppDbContext _context, IMapper _mapper) : IMenuItemService
{
    public async Task<string> AddMenuItemAsync(MenuItemCreateDTO dto)
    {
        var item = _mapper.Map<MenuItem>(dto);
        await _context.MenuItems.AddAsync(item);
        await _context.SaveChangesAsync();
        return item.Id.ToString();
    }

    public async Task ArchiveMenuItemByIdAsync(string id)
    {
        var item = await _getMenuItemAsync(id);
        item.IsArchived = !item.IsArchived;
        item.ArchivedAt = item.IsArchived ? DateTime.UtcNow : null;
        await _context.SaveChangesAsync();
    }

    public async Task<MenuItemGetDTO> GetMenuItemByIdAsync(string id)
    {
        return _mapper.Map<MenuItemGetDTO>(await _getMenuItemAsync(id));
    }

    public async Task<IEnumerable<MenuItemGetDTO>> GetMenuItemsAsync(GetListDTO dto)
    {
        var items = await _context.MenuItems.Where(x => x.IsArchived == dto.IsArchived).Skip(dto.Skip).Take(dto.Take).ToListAsync();
        return _mapper.Map<IEnumerable<MenuItemGetDTO>>(items);
    }

    public async Task RemoveMenuItemByIdAsync(string id)
    {
        await Task.Run(async () => _context.MenuItems.Remove(await _getMenuItemAsync(id)));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(MenuItemUpdateDTO dto)
    {
        _mapper.Map(dto, await _getMenuItemAsync(dto.Id));
        await _context.SaveChangesAsync();
    }

    private async Task<MenuItem> _getMenuItemAsync(string id)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (menuItem == null) throw new NotFoundException<MenuItem>();
        return menuItem;
    }
}
