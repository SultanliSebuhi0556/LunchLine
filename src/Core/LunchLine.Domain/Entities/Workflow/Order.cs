using LunchLine.Domain.Entities.Common;
using LunchLine.Domain.Enums;

namespace LunchLine.Domain.Entities.Workflow;

public class Order : BaseEntity
{
    public string? Details { get; set; }
    public OrderPriority Priority { get; set; }
    public List<MenuItem> MenuItems { get; set; } = new();
    public Table Table { get; set; } = null!;
    public Guid TableId { get; set; }
}