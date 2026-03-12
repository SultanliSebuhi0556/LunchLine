using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.PositionDTOs;

public record PositionUpdateDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }
}