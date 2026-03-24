using LunchLine.Domain.Entities.Common;
using LunchLine.Domain.Enums;

namespace LunchLine.Domain.Entities.Workflow;

public class Table : BaseEntity
{
    public string Identifier { get; set; } = null!;
    public bool IsVIP { get; set; } = false;

    public int Floor { get; set; }
    public string Section { get; set; } = null!;

    public int SeatCount { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public TableDirection Direction { get; set; }

    public List<Order> Orders { get; set; } = new();
}
