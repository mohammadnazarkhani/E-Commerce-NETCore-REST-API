using System;
using System.Reflection;
using Core.DTOs.Product;
using Core.Entities;
using Core.Entities.Enums;
using Core.Mappings;

namespace Core.Tests.Mappings.ProductMappings;

public class UpdateFromDtoMethodTests
{
    Category category = new()
    {
        Id = 1,
        Name = "cat1"
    };

    Product product = new()
    {
        Id = 1,
        Name = "Old Name",
        Description = "Old Description",
        StockQuantity = 0,
        Price = 100M,
    };

    UpdateProductDto updateDto = new UpdateProductDto("New Name", "New Description", 200M, 1, 1);

    [Fact]
    public void UpdateFromDto_ShouldThrowArgumentNullException_WhenProductEntityObjIsNull()
    {
        // Arrange 
        Product prod = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => prod.UpdateFromDto(updateDto));
    }

    [Fact]
    public void UpdateFromDto_ShouldThrowArgumentNullException_WhenUpdateProductDtoIsNull()
    {
        // Arrange 
        UpdateProductDto dto = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => product.UpdateFromDto(dto));
    }

    [Fact]
    public void UpdateFromDto_ShouldThrowValidationException_WhenDtoValidationFails()
    {
        // Arrange
        UpdateProductDto dto = new UpdateProductDto(null!, null!, -1, 1, 1);

        // Act & Assert 
        var exception = Assert.Throws<FluentValidation.ValidationException>(() => product.UpdateFromDto(dto));
    }

    [Fact]
    public void UpdateFromDto_CanUpdateProductEntityByUpdateProductDto()
    {
        // Act
        product.UpdateFromDto(updateDto);

        // Assert
        Assert.NotNull(product);
        Assert.Equal("New Name", product.Name);
        Assert.Equal("New Description", product.Description);
        Assert.Equal(200M, product.Price);
        Assert.Equal(1, product.StockQuantity);
        Assert.Equal(EntityStatus.Modified, product.Status);
    }
}
