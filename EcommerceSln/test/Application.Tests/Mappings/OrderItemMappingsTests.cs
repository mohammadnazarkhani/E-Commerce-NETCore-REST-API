using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace Application.Tests.Mappings;

public class OrderItemMappingsTests
{
    private readonly IMapper _mapper;
    
    public OrderItemMappingsTests()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => {
                cfg.AddProfile<OrderItemMappings>();
                cfg.AddProfile<ProductMappings>(); // Required for mapping product
                cfg.AddProfile<CategoryMappings>(); // Required for product's category
            }
        );
        
        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public void Map_OrderItem_To_OrderItemDto_Should_Map_Correctly()
    {
        // Arrange
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test Category"
        };

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            Price = 99.99m,
            SKU = "TEST-123",
            CategoryId = category.Id,
            Category = category
        };

        var orderItem = new OrderItem
        {
            Id = Guid.NewGuid(),
            Quantity = 2,
            UnitPrice = 99.99m,
            Subtotal = 199.98m,
            OrderId = Guid.NewGuid(),
            ProductId = product.Id,
            Product = product
        };

        // Act
        var result = _mapper.Map<OrderItemDto>(orderItem);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(orderItem.Id);
        result.Quantity.Should().Be(orderItem.Quantity);
        result.UnitPrice.Should().Be(orderItem.UnitPrice);
        result.Subtotal.Should().Be(orderItem.Subtotal);
        result.OrderId.Should().Be(orderItem.OrderId);
        
        // Product assertions
        result.Product.Should().NotBeNull();
        result.Product.Id.Should().Be(product.Id);
        result.Product.Name.Should().Be(product.Name);
        result.Product.Price.Should().Be(product.Price);

    }
}
