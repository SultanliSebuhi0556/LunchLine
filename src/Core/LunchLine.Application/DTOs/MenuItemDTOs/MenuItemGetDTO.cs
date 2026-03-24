using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.MenuItemDTOs;

public record MenuItemGetDTO : BaseGetDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MenuItemType Type { get; set; }
    public bool IsVIP { get; set; }
}