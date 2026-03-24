using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.OrderDTOs;

namespace LunchLine.Application.Abstractions.Services;

public interface IOrderService
{
    Task<string> AddOrderAsync(OrderCreateDTO dto);
    Task RemoveOrderByIdAsync(string id);
    Task ArchiveOrderByIdAsync(string id);
    Task<OrderGetDTO> GetOrderByIdAsync(string id);
    Task<IEnumerable<OrderGetDTO>> GetOrdersAsync(GetListDTO dto);
}