using LunchLine.Application.Abstractions.Commons;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.Mvc;

namespace LunchLine.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService _service, IValidationService _validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeCreateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.AddEmployeeAsync(dto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        await _service.UpdateEmployeeAsync(dto);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ArchiveEmployee([FromBody] string id)
    {
        await _service.ArchiveEmployeeByIdAsync(id);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveEmployee([FromBody] string id)
    {
        await _service.RemoveEmployeeByIdAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetEmployeeById([FromQuery] string id)
    {
        return Ok(await _service.GetEmployeeByIdAsync(id));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetEmployees([FromQuery] GetListDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.GetEmployeesAsync(dto));
    }
}