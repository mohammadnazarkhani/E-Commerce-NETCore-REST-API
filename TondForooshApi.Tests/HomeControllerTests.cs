using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TondForooshApi.Controllers;
using TondForooshApi.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MockQueryable;

namespace TondForooshApi.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Can_Use_Repository()
        {
            // Arrange
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };

            Mock<ITondForooshRepository> mock = new();
            mock.Setup(m => m.Products).Returns((new Product[] {
                p1, p2
            }).AsQueryable<Product>());

            HomeController controller = new(mock.Object);

            // Act
            var result = controller.GetProducts();
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

        [Fact]
        public async Task Can_Get_Single_Product()
        {
            // Arrange 
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };

            // - create mock repo
            Mock<ITondForooshRepository> mockRepo = new();
            mockRepo.Setup(m => m.Products).Returns(new List<Product> { p1, p2 }.AsQueryable().BuildMock());

            // - create controller instance
            HomeController targetController = new(mockRepo.Object);

            // Act
            var result = await targetController.GetProduct(1);
            Product product = (result.Result as OkObjectResult)?.Value as Product ?? new Product();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Result is OkObjectResult);
            Assert.Equal(p1, product);
        }
    }
}
