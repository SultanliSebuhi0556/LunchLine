namespace LunchLine.Application.DTOs.CommonDTOs;

public record GetBaseDTO
{
    public string Id { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}