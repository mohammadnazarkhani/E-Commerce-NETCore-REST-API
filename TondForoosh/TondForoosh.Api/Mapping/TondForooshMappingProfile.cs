using AutoMapper;
using TondForoosh.Api.Dtos.Category;
using TondForoosh.Api.Dtos.Product;
using TondForoosh.Api.Dtos.User;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public class TondForooshMappingProfile : Profile
    {
        public TondForooshMappingProfile()
        {
            // Category Mappings
            CreateMap<CreateCategoryDto, ProductCategory>();  // CreateCategoryDto -> ProductCategory
            CreateMap<UpdateCategoryDto, ProductCategory>();  // UpdateCategoryDto -> ProductCategory
            CreateMap<ProductCategory, CategoryDto>();        // ProductCategory -> CategoryDto

            // Product Mappings
            CreateMap<CreateProductDto, Product>();           // CreateProductDto -> Product
            CreateMap<UpdateProductDto, Product>();           // UpdateProductDto -> Product
            CreateMap<Product, ProductDto>();                 // Product -> ProductDto
            CreateMap<Product, ProductDetailDto>();           // Product -> ProductDetailDto

            // User Mappings
            CreateMap<CreateUserDto, User>();                 // CreateUserDto -> User
            CreateMap<RegisterUserDto, User>()                // RegisterUserDto -> User
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.User)); // Default role for registered users
            CreateMap<UpdateUserDto, User>();                 // UpdateUserDto -> User
            CreateMap<User, UserDto>();                       // User -> UserDto

            // Login Mappings
            CreateMap<LoginUserDto, User>();                  // LoginUserDto -> User
        }
    }
}
