using LunchLine.Application.DTOs.CommonDTOs;

namespace LunchLine.Application.DTOs.EmployeeDTOs;

public record EmployeeGetDTO : BaseGetDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PositionId { get; set; }
    public bool? Gender { get; set; }
    public decimal Salary { get; set; }
    public decimal MonthlyTips { get; set; }
    public decimal TotalTips { get; set; }
}
