using AutoMapper;
using LunchLine.Application.Abstractions.Services;
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
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (employee == null) throw new NotFoundException<Employee>();

        employee.IsArchived = true;
        employee.ArchivedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeGetDTO> GetEmployeeByIdAsync(string id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (employee == null) throw new NotFoundException<Employee>();

        return _mapper.Map<EmployeeGetDTO>(employee);
    }

    public async Task<IEnumerable<EmployeeGetDTO>> GetEmployeesAsync(string skip, string take)
    {
        var employees = await _context.Employees.ToListAsync
    }

    public Task RemoveEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployeeAsync(string id, EmployeeUpdateDTO dto)
    {
        throw new NotImplementedException();
    }
}