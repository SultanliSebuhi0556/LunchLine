using AutoMapper;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.TableDTOs;
using LunchLine.Application.Exceptions.Commons;
using LunchLine.Domain.Entities.Workflow;
using LunchLine.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LunchLine.Persistence.Concretes.Services;

public class TableService(AppDbContext _context, IMapper _mapper) : ITableService
{
    public async Task<string> AddTableAsync(TableCreateDTO dto)
    {
        var table = _mapper.Map<Table>(dto);
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
        return table.Id.ToString();
    }

    public async Task ArchiveTableByIdAsync(string id)
    {
        var table = await _getTableAsync(id);
        table.IsArchived = !table.IsArchived;
        table.ArchivedAt = table.IsArchived ? DateTime.UtcNow : null;
        await _context.SaveChangesAsync();
    }

    public async Task<TableGetDTO> GetTableByIdAsync(string id)
    {
        return _mapper.Map<TableGetDTO>(await _getTableAsync(id));
    }

    public async Task<IEnumerable<TableGetDTO>> GetTablesAsync(GetListDTO dto)
    {
        var employees = await _context.Tables.Where(x => x.IsArchived == dto.IsArchived).Skip(dto.Skip).Take(dto.Take).ToListAsync();
        return _mapper.Map<IEnumerable<TableGetDTO>>(employees);
    }

    public async Task RemoveTableByIdAsync(string id)
    {
        await Task.Run(async () => _context.Tables.Remove(await _getTableAsync(id)));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTableAsync(TableUpdateDTO dto)
    {
        _mapper.Map(dto, await _getTableAsync(dto.Id));
        await _context.SaveChangesAsync();
    }

    private async Task<Table> _getTableAsync(string id)
    {
        var table = await _context.Tables.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (table == null) throw new NotFoundException<Table>();
        return table;
    }
}