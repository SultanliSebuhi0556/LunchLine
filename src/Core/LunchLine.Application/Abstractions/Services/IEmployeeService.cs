using LunchLine.Application.DTOs.CommonDTOs;
using LunchLine.Application.DTOs.EmployeeDTOs;

namespace LunchLine.Application.Abstractions.Services;

public interface IEmployeeService
{
    Task<string> AddEmployeeAsync(EmployeeCreateDTO dto);
    Task RemoveEmployeeByIdAsync(string id);
    Task ArchiveEmployeeByIdAsync(string id);
    Task UpdateEmployeeAsync(string id, EmployeeUpdateDTO dto);

    Task AssignPositionAsync(string employeeId, string positionId);

    Task<EmployeeGetDTO> GetEmployeeByIdAsync(string id);
    Task<IEnumerable<EmployeeGetDTO>> GetEmployeesAsync(GetListDTO dto);
}