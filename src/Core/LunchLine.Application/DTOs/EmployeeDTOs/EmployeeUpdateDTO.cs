namespace LunchLine.Application.DTOs.EmployeeDTOs;

public record EmployeeUpdateDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool? Gender { get; set; }
    public decimal Salary { get; set; }
    public string PositionId { get; set; }
}