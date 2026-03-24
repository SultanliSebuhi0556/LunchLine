using LunchLine.Domain.Entities.Common;
using LunchLine.Domain.Enums;

namespace LunchLine.Domain.Entities.Workflow;

public class MenuItem : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public MenuItemType Type { get; set; }
    public bool IsVIP { get; set; }
}
