using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.OrderItemDTOs;
using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.OrderDTOs;

public record OrderGetDTO : BaseGetDTO
{
    public string? Details { get; set; }
    public OrderPriority Priority { get; set; }
    public IEnumerable<OrderItemGetDTO> OrderItems { get; set; }
    public string TableId { get; set; }
    public string EmployeeId { get; set; }
    public decimal TotalPrice { get; set; }
}