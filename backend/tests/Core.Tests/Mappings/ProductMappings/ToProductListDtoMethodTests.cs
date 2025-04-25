using System;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings.ProductMappings;

public class ToProductListDtoMethodTests
{
    [Fact]
    public void ToProductLIstDto_ShouldThrowArgumentNullException_WhenProductIsNull()
    {
        // Arrange
        Product product = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => product.ToProductListDto());
    }
}
