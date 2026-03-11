using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.PositionDTOs;

namespace LunchLine.Application.Abstractions.Services;

public interface IPositionService
{
    Task<string> AddPositionAsync(PositionCreateDTO dto);
    Task RemovePositionByIdAsync(string id);
    Task ArchivePositionByIdAsync(string id);
    Task UpdatePositionAsync(string id, PositionUpdateDTO dto);

    Task<PositionGetDTO> GetPositionByIdAsync(string id);
    Task<IEnumerable<PositionGetDTO>> GetPositionsAsync(GetListDTO dto);
}