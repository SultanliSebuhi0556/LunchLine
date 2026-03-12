using AutoMapper;
using LunchLine.Application.DTOs.PositionDTOs;
using LunchLine.Domain.Entities;

namespace LunchLine.Application.MapperProfiles;

public class PositionProfiles : Profile
{
    public PositionProfiles()
    {
        CreateMap<PositionCreateDTO, Position>();
        CreateMap<PositionUpdateDTO, Position>().ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<Position, PositionGetDTO>();
    }
}