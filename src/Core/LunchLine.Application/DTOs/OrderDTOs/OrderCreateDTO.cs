using LunchLine.Application.DTOs.OrderItemDTOs;
using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.OrderDTOs;

public record OrderCreateDTO
{
    public string? Details { get; set; }
    public OrderPriority Priority { get; set; }
    public IEnumerable<OrderItemCreateDTO> OrderItems { get; set; }
    public string TableId { get; set; }
    public string EmployeeId { get; set; }
}