using LunchLine.Application.DTOs.EmployeeDTOs.CommonDTOs;

namespace LunchLine.Application.DTOs.EmployeeDTOs;

public record EmployeeGetDTO : GetBaseDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PositionId { get; set; }
    public bool? Gender { get; set; }
    public float Salary { get; set; }
    public float MounthlyTips { get; set; }
    public float TotalTips { get; set; }
}
