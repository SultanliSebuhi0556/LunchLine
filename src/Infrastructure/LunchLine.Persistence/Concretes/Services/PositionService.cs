using AutoMapper;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.PositionDTOs;
using LunchLine.Application.Exceptions;
using LunchLine.Domain.Entities;
using LunchLine.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LunchLine.Persistence.Concretes.Services;

public class PositionService(AppDbContext _context, IMapper _mapper) : IPositionService
{
    public async Task<string> AddPositionAsync(PositionCreateDTO dto)
    {
        var position = _mapper.Map<Position>(dto);
        await _context.AddAsync(position);
        await _context.SaveChangesAsync();
        return position.Id.ToString();
    }

    public async Task ArchivePositionByIdAsync(string id)
    {
        var position = await _getPosition(id);
        position.IsArchived = true;
        position.ArchivedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task<PositionGetDTO> GetPositionByIdAsync(string id)
    {
        var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (position == null) throw new NotFoundException<Position>();

        return _mapper.Map<PositionGetDTO>(position);
    }

    public async Task<IEnumerable<PositionGetDTO>> GetPositionsAsync(GetListDTO dto)
    {
        var positions = await _context.Positions.Skip(dto.Skip).Take(dto.Take).ToListAsync();
        return _mapper.Map<IEnumerable<PositionGetDTO>>(positions);
    }

    public async Task RemovePositionByIdAsync(string id)
    {
        await Task.Run(async () => _context.Remove(await _getPosition(id)));
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePositionAsync(string id, PositionUpdateDTO dto)
    {
        _mapper.Map(dto, await _getPosition(id));
        await _context.SaveChangesAsync();
    }

    private async Task<Position> _getPosition(string id)
    {
        var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (position == null) throw new NotFoundException<Position>();
        return position;
    }
}