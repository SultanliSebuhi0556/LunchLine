using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.TableDTOs;

namespace LunchLine.Application.Abstractions.Services;

public interface ITableService
{
    Task<string> AddTableAsync(TableCreateDTO dto);
    Task RemoveTableByIdAsync(string id);
    Task ArchiveTableByIdAsync(string id);
    Task UpdateTableAsync(TableUpdateDTO dto);

    Task<TableGetDTO> GetTableByIdAsync(string id);
    Task<IEnumerable<TableGetDTO>> GetTablesAsync(GetListDTO dto);
}