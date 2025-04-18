using System;
using Core.DTOs.Product;
using Core.Mappings;

namespace Core.Tests.Mappings.ProductMappings;

public class ToNewProductEntitiesMethodTests
{
    [Fact]
    public void ToNewProductEntities_ThrowsArgumentNullException_WhenNullCreateProductDtoProvided()
    {
        // Arrange
        CreateProductDto createProductDto = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => createProductDto.ToNewProductEntities());
    }

    [Fact]
    public void ToNewProductEntities_ThrowsArgumentNullException_WhenNullImageFileProvided()
    {
        // Arrange
        CreateProductDto createProductDto = new()
        {
            Name = "product",
            Description = "description",
            Price = 100M,
            CategoryId = 1,
            ImageName = "name",
            Image = null!,
            StockQuantity = 0
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => createProductDto.ToNewProductEntities());
    }
}
