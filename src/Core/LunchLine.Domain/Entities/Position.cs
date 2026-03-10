using LunchLine.Domain.Entities.Common;
using LunchLine.Domain.Enums;

namespace LunchLine.Domain.Entities;

public class Position : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Employee> Employees { get; set; } = [];
    public Role Role { get; set; } = Role.Viewer;
}