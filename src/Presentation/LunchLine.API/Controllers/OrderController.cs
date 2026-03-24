using LunchLine.Application.Abstractions.Commons;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Mvc;

namespace LunchLine.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService _service, IValidationService _validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> AddOrder([FromBody] OrderCreateDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.AddOrderAsync(dto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ArchiveOrder([FromBody] string id)
    {
        await _service.ArchiveOrderByIdAsync(id);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveOrder([FromBody] string id)
    {
        await _service.RemoveOrderByIdAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetOrderById([FromQuery] string id)
    {
        return Ok(await _service.GetOrderByIdAsync(id));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetOrders([FromQuery] GetListDTO dto)
    {
        await _validator.ValidateAsync(dto);
        return Ok(await _service.GetOrdersAsync(dto));
    }
}
