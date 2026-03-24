using AutoMapper;
using LunchLine.Application.DTOs.OrderDTOs;
using LunchLine.Application.DTOs.OrderItemDTOs;
using LunchLine.Domain.Entities.Workflow;

namespace LunchLine.Application.MapperProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderGetDTO>()
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderItems.Sum(x => x.Quantity * x.UnitPrice)));

        CreateMap<OrderCreateDTO, Order>();

        CreateMap<OrderItem, OrderItemGetDTO>()
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.UnitPrice))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MenuItem.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.MenuItem.Type))
            .ForMember(dest => dest.IsVIP, opt => opt.MapFrom(src => src.MenuItem.IsVIP));

        CreateMap<OrderItemCreateDTO, OrderItem>()
            .ForMember(dest => dest.UnitPrice, opt => opt.Ignore());
    }
}