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
}
