using AutoMapper;
using LunchLine.Application.DTOs.PositionDTOs;
using LunchLine.Domain.Entities;

namespace LunchLine.Application.MapperProfiles;

public class PositionProfiles : Profile
{
    protected PositionProfiles()
    {
        CreateMap<PositionCreateDTO, Position>();
        CreateMap<PositionUpdateDTO, Position>();
        CreateMap<Position, PositionGetDTO>();
    }
}