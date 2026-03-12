namespace LunchLine.Application.DTOs.CommonDTOs;

public record GetListDTO
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; }
    public bool IsArchived { get; set; } = false;
}