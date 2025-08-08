using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Enums;

namespace Application.Mappings;

public class OrderMappings : Profile
{
    public OrderMappings()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<Order, OrderSummaryDto>();

        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.OrderNumber, opt => 
                opt.MapFrom(src => GenerateOrderNumber()))
            .ForMember(dest => dest.Status, opt => 
                opt.MapFrom(src => OrderStatus.Pending))
            .ForMember(dest => dest.OrderDate, opt => 
                opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateOrderStatusDto, Order>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }

    private static string GenerateOrderNumber()
    {
        return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N").Substring(0, 8)}".ToUpper();
    }
}
