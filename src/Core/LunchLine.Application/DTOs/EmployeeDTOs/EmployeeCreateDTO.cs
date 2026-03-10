namespace LunchLine.Application.DTOs.EmployeeDTOs;

public record EmployeeCreateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PositionId { get; set; }
    public bool? Gender { get; set; }
    public float Salary { get; set; }
}