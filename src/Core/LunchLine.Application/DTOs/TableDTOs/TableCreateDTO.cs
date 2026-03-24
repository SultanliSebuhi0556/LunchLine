namespace LunchLine.Application.DTOs.TableDTOs;

public record TableCreateDTO
{
    public string Identifier { get; set; }
    public bool IsVIP { get; set; }

    public int Floor { get; set; }
    public string Section { get; set; }

    public int SeatCount { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Direction { get; set; }
}