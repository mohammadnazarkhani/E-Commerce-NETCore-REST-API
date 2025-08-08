using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace Application.Tests.Mappings;

public class ProductMappingsTests
{
    private readonly IMapper _mapper;
    
    public ProductMappingsTests()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => {
                cfg.AddProfile<ProductMappings>();
                cfg.AddProfile<CategoryMappings>(); // Required for mapping category
            }
        );
        
        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public void Map_Product_To_ProductDto_Should_Map_Correctly()
    {
        // Arrange
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test Category",
            Description = "Test Description"
        };
        
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            Description = "Test Description",
            Price = 99.99m,
            StockQuantity = 100,
            SKU = "TEST-123",
            IsAvailable = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CategoryId = category.Id,
            Category = category
        };

        // Act
        var result = _mapper.Map<ProductDto>(product);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(product.Id);
        result.Name.Should().Be(product.Name);
        result.Description.Should().Be(product.Description);
        result.Price.Should().Be(product.Price);
        result.StockQuantity.Should().Be(product.StockQuantity);
        result.SKU.Should().Be(product.SKU);
        result.IsAvailable.Should().Be(product.IsAvailable);
        result.CreatedAt.Should().Be(product.CreatedAt);
        result.UpdatedAt.Should().Be(product.UpdatedAt);
        result.Category.Should().NotBeNull();
        result.Category.Id.Should().Be(category.Id);
        result.Category.Name.Should().Be(category.Name);
    }

    [Fact]
    public void Map_Product_To_ProductSummaryDto_Should_Map_Correctly()
    {
        // Arrange
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            Price = 99.99m,
            SKU = "TEST-123"
        };

        // Act
        var result = _mapper.Map<ProductSummaryDto>(product);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(product.Id);
        result.Name.Should().Be(product.Name);
        result.Price.Should().Be(product.Price);
        result.IsAvailable.Should().Be(product.IsAvailable);
    }

    [Fact]
    public void Map_CreateProductDto_To_Product_Should_Map_Correctly()
    {
        // Arrange
        var createDto = new CreateProductDto(
            "Test Product",
            "Test Description",
            99.99m,
            100,
            "TEST-123",
            true,
            Guid.NewGuid()
        );

        // Act
        var result = _mapper.Map<Product>(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(createDto.Name);
        result.Description.Should().Be(createDto.Description);
        result.Price.Should().Be(createDto.Price);
        result.StockQuantity.Should().Be(createDto.StockQuantity);
        result.SKU.Should().Be(createDto.SKU);
        result.IsAvailable.Should().Be(createDto.IsAvailable);
        result.CategoryId.Should().Be(createDto.CategoryId);
    }
}
