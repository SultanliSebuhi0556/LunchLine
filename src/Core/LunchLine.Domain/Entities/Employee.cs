using LunchLine.Domain.Entities.Common;

namespace LunchLine.Domain.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Position Position { get; set; } = null!;
    public Guid PositionId { get; set; }
    public bool? Gender { get; set; }
    public float Salary { get; set; }
    public float MonthlyTips { get; set; }
    public float TotalTips { get; set; }
}