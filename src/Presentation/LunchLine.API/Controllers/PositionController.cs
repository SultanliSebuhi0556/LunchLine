using LunchLine.Application.Abstractions.Commons;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.PositionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace LunchLine.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionController(IPositionService _service, IValidationService _validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> AddPosition([FromBody] PositionCreateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.AddPositionAsync(dto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdatePosition([FromBody] PositionUpdateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        await _service.UpdatePositionAsync(dto);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ArchivePosition([FromBody] string id)
    {
        await _service.ArchivePositionByIdAsync(id);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemovePosition([FromBody] string id)
    {
        await _service.RemovePositionByIdAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPositionById([FromQuery] string id)
    {
        return Ok(await _service.GetPositionByIdAsync(id));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPositions([FromQuery] GetListDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.GetPositionsAsync(dto));
    }
}