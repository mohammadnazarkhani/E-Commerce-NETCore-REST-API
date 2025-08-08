using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        CreateMap<Product, ProductSummaryDto>();

        CreateMap<CreateProductDto, Product>();
        
        CreateMap<UpdateProductDto, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
