using AutoMapper;
using LunchLine.Application.DTOs.EmployeeDTOs;
using LunchLine.Domain.Entities;

namespace LunchLine.Application.MapperProfiles;

public class EmployeeProfiles : Profile
{
    public EmployeeProfiles()
    {
        CreateMap<EmployeeCreateDTO, Employee>();
        CreateMap<EmployeeUpdateDTO, Employee>().ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<Employee, EmployeeGetDTO>();
    }
}