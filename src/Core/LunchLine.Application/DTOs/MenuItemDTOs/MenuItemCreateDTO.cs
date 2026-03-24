using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.MenuItemDTOs;

public record MenuItemCreateDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MenuItemType Type { get; set; }
    public bool IsVIP { get; set; }
}