using AutoMapper;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    // Create a mapping profile for AutoMapper
    public class TondForooshMappingProfile : Profile
    {
        public TondForooshMappingProfile()
        {
            // Category Mappings
            CreateMap<CreateCategoryDto, ProductCategory>();  // CreateCategoryDto -> ProductCategory
            CreateMap<UpdateCategoryDto, ProductCategory>();  // UpdateCategoryDto -> ProductCategory
            CreateMap<ProductCategory, CategoryDto>();        // ProductCategory -> CategoryDto

            // Product Mappings
            CreateMap<CreateProductDto, Product>();          // CreateProductDto -> Product
            CreateMap<UpdateProductDto, Product>();          // UpdateProductDto -> Product
            CreateMap<Product, ProductDto>();                // Product -> ProductDto
            CreateMap<Product, ProductDetailDto>();          // Product -> ProductDetailDto

            // User Mappings
            CreateMap<RegisterUserDto, User>();              // RegisterUserDto -> User

            // You can add more mappings for other entities as needed
        }
    }
}
