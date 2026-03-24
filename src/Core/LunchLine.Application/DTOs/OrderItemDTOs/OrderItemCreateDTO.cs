namespace LunchLine.Application.DTOs.OrderItemDTOs;

public record OrderItemCreateDTO
{
    public string MenuItemId { get; set; }
    public int Quantity { get; set; }
}