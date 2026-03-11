using AutoMapper;
using LunchLine.Application.Abstractions.Services;
using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.EmployeeDTOs;
using LunchLine.Application.Exceptions;
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
        var employee = await _getEmployee(id);
        employee.IsArchived = true;
        employee.ArchivedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task AssignPositionAsync(string employeeId, string positionId)
    {
        var employee = await _getEmployee(employeeId);
        var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id.ToString() == positionId);
        if (position == null) throw new NotFoundException<Position>();

        employee.Position = position;
        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeGetDTO> GetEmployeeByIdAsync(string id)
    {
        return _mapper.Map<EmployeeGetDTO>(await _getEmployee(id));
    }

    public async Task<IEnumerable<EmployeeGetDTO>> GetEmployeesAsync(GetListDTO dto)
    {
        var employees = await _context.Employees.Skip(dto.Skip).Take(dto.Take).ToListAsync();
        return _mapper.Map<IEnumerable<EmployeeGetDTO>>(employees);
    }

    public async Task RemoveEmployeeByIdAsync(string id)
    {
        await Task.Run(async () => _context.Remove(await _getEmployee(id)));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(string id, EmployeeUpdateDTO dto)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (employee == null) throw new NotFoundException<Employee>();
        _mapper.Map(dto, employee);
        await _context.SaveChangesAsync();
    }

    private async Task<Employee> _getEmployee(string id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (employee == null) throw new NotFoundException<Employee>();
        return employee;
    }
}