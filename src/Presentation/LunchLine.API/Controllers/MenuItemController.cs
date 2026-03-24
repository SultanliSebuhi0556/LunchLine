using LunchLine.Application.Abstractions.Commons;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.MenuItemDTOs;
using Microsoft.AspNetCore.Mvc;

namespace LunchLine.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController(IMenuItemService _service, IValidationService _validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> AddMenuItem([FromBody] MenuItemCreateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.AddMenuItemAsync(dto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateMenuItem([FromBody] MenuItemUpdateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        await _service.UpdateMenuItemAsync(dto);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ArchiveMenuItem([FromBody] string id)
    {
        await _service.ArchiveMenuItemByIdAsync(id);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveMenuItem([FromBody] string id)
    {
        await _service.RemoveMenuItemByIdAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetMenuItemById([FromQuery] string id)
    {
        return Ok(await _service.GetMenuItemByIdAsync(id));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetMenuItems([FromQuery] GetListDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.GetMenuItemsAsync(dto));
    }
}
