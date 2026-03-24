using AutoMapper;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.EmployeeDTOs;
using LunchLine.Application.Exceptions.Commons;
using LunchLine.Domain.Entities;
using LunchLine.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LunchLine.Persistence.Concretes.Services;

public class EmployeeService(AppDbContext _context, IMapper _mapper) : IEmployeeService
{
    public async Task<string> AddEmployeeAsync(EmployeeCreateDTO dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee.Id.ToString();
    }

    public async Task ArchiveEmployeeByIdAsync(string id)
    {
        var employee = await _getEmployeeAsync(id);
        employee.IsArchived = !employee.IsArchived;
        employee.ArchivedAt = employee.IsArchived ? DateTime.UtcNow : null;
        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeGetDTO> GetEmployeeByIdAsync(string id)
    {
        return _mapper.Map<EmployeeGetDTO>(await _getEmployeeAsync(id));
    }

    public async Task<IEnumerable<EmployeeGetDTO>> GetEmployeesAsync(GetListDTO dto)
    {
        var employees = await _context.Employees.Where(x => x.IsArchived == dto.IsArchived).Skip(dto.Skip).Take(dto.Take).ToListAsync();
        return _mapper.Map<IEnumerable<EmployeeGetDTO>>(employees);
    }

    public async Task RemoveEmployeeByIdAsync(string id)
    {
        await Task.Run(async () => _context.Remove(await _getEmployeeAsync(id)));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(EmployeeUpdateDTO dto)
    {
        if (!await _context.Positions.AnyAsync(x => x.Id.ToString() == dto.Id)) throw new NotFoundException<Position>();
        _mapper.Map(dto, await _getEmployeeAsync(dto.Id));
        await _context.SaveChangesAsync();
    }

    private async Task<Employee> _getEmployeeAsync(string id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (employee == null) throw new NotFoundException<Employee>();
        return employee;
    }
}