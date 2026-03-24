using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.MenuItemDTOs;

namespace LunchLine.Application.Abstractions.Services;

public interface IMenuItemService
{
    Task<string> AddMenuItemAsync(MenuItemCreateDTO dto);
    Task RemoveMenuItemByIdAsync(string id);
    Task ArchiveMenuItemByIdAsync(string id);
    Task UpdateMenuItemAsync(MenuItemUpdateDTO dto);

    Task<MenuItemGetDTO> GetMenuItemByIdAsync(string id);
    Task<IEnumerable<MenuItemGetDTO>> GetMenuItemsAsync(GetListDTO dto);
}