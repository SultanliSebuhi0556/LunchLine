using LunchLine.Domain.Entities.Common;
using LunchLine.Domain.Entities.Workflow;

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
    public decimal Salary { get; set; }
    public decimal MonthlyTips { get; set; }
    public decimal TotalTips { get; set; }
    public List<Order> Orders { get; set; } = new();
}
