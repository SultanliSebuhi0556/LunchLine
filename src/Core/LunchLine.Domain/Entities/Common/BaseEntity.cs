namespace LunchLine.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsArchived { get; set; } = false;
    public DateTime? ArchivedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}