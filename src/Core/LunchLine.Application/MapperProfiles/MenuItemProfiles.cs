using AutoMapper;
using LunchLine.Application.DTOs.MenuItemDTOs;
using LunchLine.Domain.Entities.Workflow;

namespace LunchLine.Application.MapperProfiles;

public class MenuItemProfiles : Profile
{
    public MenuItemProfiles()
    {
        CreateMap<MenuItemCreateDTO, MenuItem>();
        CreateMap<MenuItemUpdateDTO, MenuItem>().ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<MenuItem, MenuItemGetDTO>();
    }
}