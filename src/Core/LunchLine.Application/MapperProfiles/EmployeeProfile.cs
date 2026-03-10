using AutoMapper;
using LunchLine.Application.DTOs.EmployeeDTOs;
using LunchLine.Domain.Entities;

namespace LunchLine.Application.MapperProfiles;

public class EmployeeProfile : Profile
{
    protected EmployeeProfile()
    {
        CreateMap<EmployeeCreateDTO, Employee>();
        CreateMap<EmployeeUpdateDTO, Employee>();
        CreateMap<Employee, EmployeeGetDTO>();
    }
}