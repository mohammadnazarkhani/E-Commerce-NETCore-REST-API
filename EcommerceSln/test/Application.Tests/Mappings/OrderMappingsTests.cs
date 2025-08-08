using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Enums;
using FluentAssertions;

namespace Application.Tests.Mappings;

public class OrderMappingsTests
{
    private readonly IMapper _mapper;
    
    public OrderMappingsTests()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => {
                cfg.AddProfile<OrderMappings>();
                cfg.AddProfile<CustomerMappings>();
                cfg.AddProfile<AddressMappings>();
                cfg.AddProfile<OrderItemMappings>();
                cfg.AddProfile<ProductMappings>();
            }
        );
        
        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public void Map_Order_To_OrderDto_Should_Map_Correctly()
    {
        // Arrange
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };

        var shippingAddress = new Address
        {
            Id = Guid.NewGuid(),
            Street = "123 Test St",
            City = "Test City",
            State = "Test State",
            Country = "Test Country",
            PostalCode = "12345",
            CustomerId = customer.Id
        };

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
            ProductId = product.Id,
            Product = product
        };

        var order = new Order
        {
            Id = Guid.NewGuid(),
            OrderNumber = "ORD-2025-001",
            Status = OrderStatus.Pending,
            TotalAmount = 199.98m,
            OrderDate = DateTime.UtcNow,
            ShippedDate = null,
            CustomerId = customer.Id,
            Customer = customer,
            ShippingAddressId = shippingAddress.Id,
            ShippingAddress = shippingAddress,
            OrderItems = new List<OrderItem> { orderItem }
        };

        // Act
        var result = _mapper.Map<OrderDto>(order);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(order.Id);
        result.OrderNumber.Should().Be(order.OrderNumber);
        result.Status.Should().Be(order.Status);
        result.TotalAmount.Should().Be(order.TotalAmount);
        result.OrderDate.Should().Be(order.OrderDate);
        result.ShippedDate.Should().Be(order.ShippedDate);
        
        // Customer assertions
        result.Customer.Should().NotBeNull();
        result.Customer.Id.Should().Be(customer.Id);
        result.Customer.FirstName.Should().Be(customer.FirstName);
        result.Customer.LastName.Should().Be(customer.LastName);
        result.Customer.Email.Should().Be(customer.Email);
        
        // Shipping address assertions
        result.ShippingAddress.Should().NotBeNull();
        result.ShippingAddress.Id.Should().Be(shippingAddress.Id);
        result.ShippingAddress.Street.Should().Be(shippingAddress.Street);
        result.ShippingAddress.City.Should().Be(shippingAddress.City);
        
        // Order items assertions
        result.OrderItems.Should().NotBeNull();
        result.OrderItems.Should().HaveCount(1);
        var mappedOrderItem = result.OrderItems.First();
        mappedOrderItem.Quantity.Should().Be(orderItem.Quantity);
        mappedOrderItem.UnitPrice.Should().Be(orderItem.UnitPrice);
        mappedOrderItem.Subtotal.Should().Be(orderItem.Subtotal);
        mappedOrderItem.Product.Should().NotBeNull();
        mappedOrderItem.Product.Id.Should().Be(product.Id);
        mappedOrderItem.Product.Name.Should().Be(product.Name);
    }
}
