using LunchLine.Domain.Entities.Common;
using LunchLine.Domain.Enums;

namespace LunchLine.Domain.Entities.Workflow;

public class MenuItem : BaseEntity
{
    public string Name { get; set; } = null!;
    public float Price { get; set; }
    public List<Order> Orders { get; set; } = new();
    public MenuItemType Type { get; set; }
    public bool IsVIP { get; set; }
}