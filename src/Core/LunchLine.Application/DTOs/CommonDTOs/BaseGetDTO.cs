using System.Text.Json.Serialization;

namespace LunchLine.Application.DTOs.CommonDTOs;

public record BaseGetDTO
{
    [JsonPropertyOrder(-1)]
    public string Id { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}