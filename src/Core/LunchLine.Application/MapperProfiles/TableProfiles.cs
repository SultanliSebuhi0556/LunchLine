using AutoMapper;
using LunchLine.Application.DTOs.TableDTOs;
using LunchLine.Domain.Entities.Workflow;

namespace LunchLine.Application.MapperProfiles;

public class TableProfiles : Profile
{
    public TableProfiles()
    {
        CreateMap<TableCreateDTO, Table>();
        CreateMap<TableUpdateDTO, Table>().ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<Table, TableGetDTO>();
    }
}
