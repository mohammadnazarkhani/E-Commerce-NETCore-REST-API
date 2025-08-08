using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OrderItemMappings : Profile
{
    public OrderItemMappings()
    {
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

        CreateMap<CreateOrderItemDto, OrderItem>()
            .ForMember(dest => dest.UnitPrice, opt => opt.Ignore()) // Will be set from product price
            .ForMember(dest => dest.Subtotal, opt => opt.Ignore()); // Will be calculated
    }
}
