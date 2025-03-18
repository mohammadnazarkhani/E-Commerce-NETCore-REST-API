using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Core.Entities;
using MockQueryable;
using Core.DTOs;
using Infrastructure.Data;

namespace TondForooshApi.Tests;

public class ProductControllerTests
{
    private Category GetTestCategory()
    {
        return new Category { Id = 1, Name = "Test Category" };
    }

    #region GetAllProducts
    [Fact]
    public async Task GetProductByIds_ShouldReturnAllProducts_WhenProductsExist()
    {
        // Arrange
        var category = GetTestCategory();
        Product p1 = new Product { Id = 1, Name = "P1", CategoryId = category.Id, Category = category };
        Product p2 = new Product { Id = 2, Name = "P2", CategoryId = category.Id, Category = category };

        Mock<ITondForooshRepository> mock = new();
        mock.Setup(m => m.Products).Returns(new List<Product> { p1, p2 }.AsQueryable().BuildMock());

        ProductController controller = new(mock.Object);

        // Act
        var result = await controller.GetAllProducts();
        var okResult = result.Result as OkObjectResult;
        var products = okResult?.Value as IEnumerable<Product>;

        // Assert
        Assert.NotNull(okResult);
        Assert.NotNull(products);
        Product[] productArray = products.ToArray();
        Assert.True(productArray.Length == 2);
        Assert.Equal("P1", productArray[0].Name);
        Assert.Equal("P2", productArray[1].Name);
    }
    #endregion

    #region GetProductById
    [Fact]
    public async Task GetProductById_ShouldReturnProduct_WhenIdExists()
    {
        // Arrange 
        var category = GetTestCategory();
        Product p1 = new Product { Id = 1, Name = "P1", CategoryId = category.Id, Category = category };
        Product p2 = new Product { Id = 2, Name = "P2", CategoryId = category.Id, Category = category };

        // - create mock repo
        Mock<ITondForooshRepository> mockRepo = new();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { p1, p2 }.AsQueryable().BuildMock());

        // - create controller instance
        ProductController targetController = new(mockRepo.Object);

        // Act
        var result = await targetController.GetProductById(1);
        Product product = (result.Result as OkObjectResult)?.Value as Product ?? new Product();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Result is OkObjectResult);
        Assert.Equal(p1, product);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnNotFound_WhenIdDoesNotExist()
    {
        // Arrange 
        var category = GetTestCategory();
        Product p1 = new Product { Id = 1, Name = "P1", CategoryId = category.Id, Category = category };
        Product p2 = new Product { Id = 2, Name = "P2", CategoryId = category.Id, Category = category };

        // - create mock repo
        Mock<ITondForooshRepository> mockRepo = new();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { p1, p2 }.AsQueryable().BuildMock());

        // - create controller instance
        ProductController targetController = new(mockRepo.Object);

        // Act
        var result = await targetController.GetProductById(4);
        var actionResult = result.Result;
        Product? product = (result.Result as OkObjectResult)?.Value as Product;

        // Assert
        Assert.True(actionResult is NotFoundResult);
        Assert.Null(product);
    }
    #endregion

    #region CreateProduct
    [Fact]
    public async Task CreateProduct_ShouldCreateNewProduct_WhenValidDataProvided()
    {
        // Arrange 
        var category = GetTestCategory();
        Product p1 = new Product { Id = 1, Name = "P1", CategoryId = category.Id, Category = category };
        Product p2 = new Product { Id = 2, Name = "P2", CategoryId = category.Id, Category = category };

        // - create mock repo
        Mock<ITondForooshRepository> mockRepo = new();
        var products = new List<Product> { p1, p2 };
        mockRepo.Setup(m => m.Products).Returns(products.AsQueryable().BuildMock());
        mockRepo.Setup(m => m.AddAsync(It.IsAny<Product>())).ReturnsAsync((Product product) =>
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return product.Id;
        });
        mockRepo.Setup(m => m.Categories).Returns(new List<Category> { category }.AsQueryable().BuildMock());

        // - create controller instance
        ProductController targetController = new(mockRepo.Object);

        // - create CreateProductDto
        CreateProductDto createProductDto = new("P3", "Description", 100M, "URL", category.Id);

        // Act
        var result = await targetController.CreateProduct(createProductDto);
        var actionResult = result.Result;
        long newProductId = (actionResult as OkObjectResult)?.Value as long? ?? -1;

        // Assert
        Assert.True(actionResult is OkObjectResult);
        Assert.False(newProductId == -1);

        Product p = products.FirstOrDefault(p => p.Id == newProductId) ?? new Product();
        Assert.Equal(newProductId, p.Id);
        Assert.Equal(createProductDto.Name, p.Name);
        Assert.Equal(createProductDto.Description, p.Description);
        Assert.Equal(createProductDto.Price, p.Price);
        Assert.Equal(createProductDto.ImageUrl, p.ImageUrl);
        Assert.Equal(createProductDto.CategoryId, p.CategoryId);
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnBadRequest_WhenDtoIsNull()
    {
        // Arrange 
        var category = GetTestCategory();
        Product p1 = new Product { Id = 1, Name = "P1", CategoryId = category.Id, Category = category };
        Product p2 = new Product { Id = 2, Name = "P2", CategoryId = category.Id, Category = category };

        // - create mock repo
        Mock<ITondForooshRepository> mockRepo = new();
        var products = new List<Product> { p1, p2 };
        mockRepo.Setup(m => m.Products).Returns(products.AsQueryable().BuildMock());
        mockRepo.Setup(m => m.AddAsync(It.IsAny<Product>())).ReturnsAsync((Product product) =>
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return product.Id;
        });

        // - create controller instance
        ProductController targetController = new(mockRepo.Object);

        // - create CreateProductDto instance when null
        CreateProductDto createProductDto = null!;
        // Act
        ActionResult<long> result = await targetController.CreateProduct(createProductDto);

        // Assert
        Assert.True(result.Result is BadRequestResult);
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnBadRequest_WhenNameIsNull()
    {
        // Arrange
        Mock<ITondForooshRepository> mockRepo = new();
        ProductController targetController = new(mockRepo.Object);
        targetController.ModelState.AddModelError("Name", "Required");
        CreateProductDto createProductDto = new(null!, "Description", 100M, "URL", 1);

        // Act
        var result = await targetController.CreateProduct(createProductDto);

        // Assert
        Assert.True(result.Result is BadRequestResult);
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnBadRequest_WhenPriceIsInvalid()
    {
        // Arrange
        Mock<ITondForooshRepository> mockRepo = new();
        ProductController targetController = new(mockRepo.Object);
        targetController.ModelState.AddModelError("Price", "Out of range");
        CreateProductDto createProductDto = new("P3", "Description", 0M, "URL", 1);

        // Act
        var result = await targetController.CreateProduct(createProductDto);

        // Assert
        Assert.True(result.Result is BadRequestResult);
    }
    #endregion

    #region UpdateProduct
    [Fact]
    public async Task UpdateProduct_ShouldReturnNoContent_WhenProductIsUpdatedSuccessfully()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "P1", Description = "Old Desc", Price = 10M };
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { product }.AsQueryable().BuildMock());
        mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
        var controller = new ProductController(mockRepo.Object);
        var updateDto = new UpdateProductDto { Id = 1, Name = "Updated", Price = 20M };

        // Act
        var result = await controller.UpdateProduct(updateDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ShouldReturnNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(new List<Product>().AsQueryable().BuildMock());
        var controller = new ProductController(mockRepo.Object);
        var updateDto = new UpdateProductDto { Id = 1, Name = "Updated" };

        // Act
        var result = await controller.UpdateProduct(updateDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var mockRepo = new Mock<ITondForooshRepository>();
        var controller = new ProductController(mockRepo.Object);
        controller.ModelState.AddModelError("error", "some error");
        var updateDto = new UpdateProductDto { Id = 1 };

        // Act
        var result = await controller.UpdateProduct(updateDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ShouldReturnBadRequest_WhenDtoIsNull()
    {
        // Arrange
        var mockRepo = new Mock<ITondForooshRepository>();
        var controller = new ProductController(mockRepo.Object);

        // Act
        var result = await controller.UpdateProduct(null!);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ShouldNotUpdateProduct_WhenPriceIsInvalid()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "P1", Price = 10M };
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { product }.AsQueryable().BuildMock());
        var controller = new ProductController(mockRepo.Object);
        var updateDto = new UpdateProductDto { Id = 1, Price = -5M };

        // Act
        var result = await controller.UpdateProduct(updateDto);

        // Assert
        Assert.Equal(10M, product.Price);
    }

    [Fact]
    public async Task UpdateProduct_ShouldReturnNoContent_WhenNoFieldsAreUpdated()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "P1", Description = "Desc", Price = 10M };
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { product }.AsQueryable().BuildMock());
        mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
        var controller = new ProductController(mockRepo.Object);
        var updateDto = new UpdateProductDto { Id = 1 };

        // Act
        var result = await controller.UpdateProduct(updateDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Equal("P1", product.Name);
        Assert.Equal("Desc", product.Description);
        Assert.Equal(10M, product.Price);
    }

    [Fact]
    public async Task UpdateProduct_ShouldUpdateProductWithAllFields_WhenAllFieldsAreProvided()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "P1", Description = "Old Desc", Price = 10M, ImageUrl = "old.jpg" };
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { product }.AsQueryable().BuildMock());
        mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
        var controller = new ProductController(mockRepo.Object);
        var updateDto = new UpdateProductDto
        {
            Id = 1,
            Name = "New Name",
            Description = "New Desc",
            Price = 20M,
            ImageUrl = "new.jpg"
        };

        // Act
        var result = await controller.UpdateProduct(updateDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Equal("New Name", product.Name);
        Assert.Equal("New Desc", product.Description);
        Assert.Equal(20M, product.Price);
        Assert.Equal("new.jpg", product.ImageUrl);
    }
    #endregion

    #region DeleteProduct
    [Fact]
    public async Task DeleteProduct_ShouldReturnNotFound_WhenProductDoesNotExists()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "P1", Description = "Old Desc", Price = 10M };
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(new List<Product> { product }.AsQueryable().BuildMock());
        var controller = new ProductController(mockRepo.Object);

        // Act
        var result = await controller.DeleteProduct(2);

        // Assert
        Assert.True(result is NotFoundResult);
        Assert.Equal(1, mockRepo.Object.Products.Count());
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnNoContentResult_WhenProductDeletedSuccessfully()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "P1", Description = "Old Desc", Price = 10M };
        var productList = new List<Product> { product };
        var mockRepo = new Mock<ITondForooshRepository>();
        mockRepo.Setup(m => m.Products).Returns(productList.AsQueryable().BuildMock());
        mockRepo.Setup(m => m.DeleteAsync(It.IsAny<Product>()))
            .Callback<Product>(p => productList.Remove(p))
            .Returns(Task.CompletedTask);
        var controller = new ProductController(mockRepo.Object);

        // Act
        var result = await controller.DeleteProduct(1);

        // Assert
        Assert.True(result is NoContentResult);
        Assert.Empty(mockRepo.Object.Products);
    }
    #endregion
}
