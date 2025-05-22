using System;
using Core.DTOs.Product;
using Core.Entities;
using Core.Entities.Enums;
using Core.Mappings;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;

namespace Core.Tests.Mappings.ProductMappings;

public class ToNewProductEntitiesMethodTests
{
    [Fact]
    public void ToNewProductEntities_ShouldThrowArgumentNullException_WhenCreateProductDtoIsNull()
    {
        // Arrange
        CreateProductDto createProductDto = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => createProductDto.ToNewProductEntities());
    }

    [Fact]
    public void ToNewProductEntities_ShouldThrowArgumentNullException_WhenImageFileIsNull()
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

    [Fact]
    public void ToNewProductEntities_ShouldReturnEntities_WhenCreateProductDtoIsValid()
    {
        // Arrange - create file mock
        var fileMock = new Mock<IFormFile>();
        var content = "content";
        var filename = "img.jpg";
        var contentType = "image/jpeg";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(f => f.OpenReadStream()).Returns(ms);
        fileMock.Setup(f => f.FileName).Returns(filename);
        fileMock.Setup(f => f.Length).Returns(ms.Length);
        fileMock.Setup(f => f.ContentType).Returns(contentType);

        // create the dto
        string productName = "product";
        string productDescription = "description";
        string imageName = "img";
        CreateProductDto createProductDto = new()
        {
            Name = productName,
            Description = productDescription,
            Price = 100M,
            CategoryId = 1,
            StockQuantity = 1,
            ImageName = imageName,
            Image = fileMock.Object
        };

        // Act
        var (img, prodImg, product) = createProductDto.ToNewProductEntities();

        // Assert - returned IFormFile is same as mock
        Assert.Equal(fileMock.Object, img);
        // Assert - returned ProductImage entity is valid
        Assert.NotNull(prodImg);
        Assert.Equal(imageName, prodImg.Name);
        Assert.Equal(contentType, prodImg.ContentType);
        Assert.Equal(content.Length, prodImg.FileSize);
        Assert.Equal(product, prodImg.Product);
        Assert.Equal(EntityStatus.Added, prodImg.Status);
        // Assert - returned Product entity is valid
        Assert.NotNull(product);
        Assert.Equal(productName, product.Name);
        Assert.Equal(productDescription, product.Description);
        Assert.Equal(100M, product.Price);
        Assert.Equal(1, product.CategoryId);
        Assert.Equal(1, product.StockQuantity);
        Assert.Equal(prodImg, product.MainImage);
        Assert.Equal(EntityStatus.Added, product.Status);
    }
}
