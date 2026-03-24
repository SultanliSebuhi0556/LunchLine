using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.OrderItemDTOs;

public record OrderItemGetDTO : BaseGetDTO
{
    //public string MenuItemId { get; set; }
    public string Name { get; set; }
    public MenuItemType Type { get; set; }
    public bool IsVIP { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}