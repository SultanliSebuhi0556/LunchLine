using LunchLine.Domain.Entities.Common;

namespace LunchLine.Domain.Entities.Workflow;

public class Table : BaseEntity
{
    public string Identificator { get; set; } = null!;
    public int Floor { get; set; }
    public int SeatCount { get; set; }
    public string Section { get; set; } = null!;
    public bool IsVIP { get; set; }
}