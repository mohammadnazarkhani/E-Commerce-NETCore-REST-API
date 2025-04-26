using System;
using Core.DTOs.Product;
using Core.Entities;
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
}
