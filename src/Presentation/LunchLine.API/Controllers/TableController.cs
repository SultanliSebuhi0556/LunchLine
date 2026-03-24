using LunchLine.Application.Abstractions.Commons;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.TableDTOs;
using Microsoft.AspNetCore.Mvc;

namespace LunchLine.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TableController(ITableService _service, IValidationService _validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> AddTable([FromBody] TableCreateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.AddTableAsync(dto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateTable([FromBody] TableUpdateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        await _service.UpdateTableAsync(dto);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ArchiveTable([FromBody] string id)
    {
        await _service.ArchiveTableByIdAsync(id);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveTable([FromBody] string id)
    {
        await _service.RemoveTableByIdAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTableById([FromQuery] string id)
    {
        return Ok(await _service.GetTableByIdAsync(id));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTables([FromQuery] GetListDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.GetTablesAsync(dto));
    }
}
