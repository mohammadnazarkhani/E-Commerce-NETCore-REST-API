using System;
using Core.DTOs.Category;
using Core.DTOs.Product;
using Core.Entities;
using Core.Mappings;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace Core.Tests.Mappings.ProductMappings;

public class ToProductDetailsDtoMethodTests
{
    [Fact]
    public void ToProductDetailsDto_ShouldThrowArgumentNullException_WhenProductIsNull()
    {
        // Arrange
        Product product = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => product.ToProductDetailsDto());
    }

    [Fact]
    public void ToProductDetailsDto_ShouldMapProductEntityToProductDetailsDtoCorrectly()
    {
        // Arrange
        Category category = new()
        {
            Id = 1,
            Name = "cat1"
        };
        Product product = new Product()
        {
            Id = 1,
            Name = "product",
            Description = "description",
            Price = 100M,
            StockQuantity = 1,
            Category = category,
            CategoryId = category.Id
        };

        // Act
        ProductDetailsDto productDetailsDto = product.ToProductDetailsDto();

        // Assert - the returned dto obj not null
        Assert.NotNull(productDetailsDto);
        // Assert - the properties maped correctly
        Assert.Equal(1, productDetailsDto.Id);
        Assert.Equal("product", productDetailsDto.Name);
        Assert.Equal("description", productDetailsDto.Description);
        Assert.Equal(100M, productDetailsDto.Price);
        Assert.Equal(1, productDetailsDto.StockQuantity);
        Assert.Equal(Guid.Empty, productDetailsDto.MainImageId);
        // Assert the category chain 
        Stack<CategoryDto> categories = new Stack<CategoryDto>();
        categories.Push(category.ToDto());
        Assert.Equal(categories, productDetailsDto.Categories);
    }
}
