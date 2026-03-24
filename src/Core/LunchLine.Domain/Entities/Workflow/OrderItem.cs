using LunchLine.Domain.Entities.Common;

namespace LunchLine.Domain.Entities.Workflow;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}