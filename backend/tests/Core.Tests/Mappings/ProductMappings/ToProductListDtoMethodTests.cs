using System;
using Core.DTOs.Product;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings.ProductMappings;

public class ToProductListDtoMethodTests
{
    [Fact]
    public void ToProductListDto_ShouldThrowArgumentNullException_WhenProductIsNull()
    {
        // Arrange
        Product product = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => product.ToProductListDto());
    }

    [Fact]
    public void ToProductListDto_CanMapProductEntityToProductListDtoCurrectly()
    {
        // Arrange
        Guid imageId = Guid.NewGuid();
        Product product = new()
        {
            Id = 1,
            Name = "prod",
            Price = 100M,
            MainImage = new ProductImage { Id = imageId }
        };

        // Act
        ProductListDto dto = product.ToProductListDto();

        // Assert
        Assert.NotNull(dto);
        Assert.Equal(1, dto.Id);
        Assert.Equal("prod", dto.Name);
        Assert.Equal(100M, dto.Price);
        Assert.Equal(imageId, dto.MainImageId);
    }
}
