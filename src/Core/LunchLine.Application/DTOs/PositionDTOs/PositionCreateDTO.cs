using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.PositionDTOs;

public record PositionCreateDTO
{
    public string Name { get; set; }
    public Role Role { get; set; }
}