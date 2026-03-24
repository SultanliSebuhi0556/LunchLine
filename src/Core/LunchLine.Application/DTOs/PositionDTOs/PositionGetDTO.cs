using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.PositionDTOs;

public record PositionGetDTO : BaseGetDTO
{
    public string Name { get; set; }
    public Role Role { get; set; }
}