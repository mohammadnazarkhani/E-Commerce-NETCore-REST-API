using System;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings.ProductMappings;

public class ToProductDetailsDtoMethodTests
{
    [Fact]
    public void ToProductDetailsDto_ThrowsArgumentNullException_WhenNullProductEntityObjProvided()
    {
        // Arrange
        Product product = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => product.ToProductDetailsDto());
    }
}
