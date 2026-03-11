using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Domain.Enums;

namespace LunchLine.Application.DTOs.PositionDTOs;

public record PositionGetDTO : GetBaseDTO
{
    public string Name { get; set; }
    public IEnumerable<string> EmployeeIds { get; set; }
    public Role Role { get; set; }
}