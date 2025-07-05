using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class OrderItemValidatorTests
    {
        private OrderItem CreateValidOrderItem() => new OrderItem
        {
            Quantity = 1,
            Price = 10.0m,
            Status = ECommerce.RestAPI.Entities.Enums.OrderItemStatus.Pending,
            ProductId = Guid.NewGuid(),
            OrderId = Guid.NewGuid(),
            VendorId = Guid.NewGuid()
        };

        [Fact]
        public void OrderItem_WithValidData_ShouldBeValid()
        {
            var orderItem = CreateValidOrderItem();
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void OrderItem_QuantityZeroOrNegative_ShouldBeInvalid(int quantity)
        {
            var orderItem = CreateValidOrderItem();
            orderItem.Quantity = quantity;
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Quantity");
        }

        [Fact]
        public void OrderItem_NegativePrice_ShouldBeInvalid()
        {
            var orderItem = CreateValidOrderItem();
            orderItem.Price = -1;
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Price");
        }

        [Fact]
        public void OrderItem_InvalidStatus_ShouldBeInvalid()
        {
            var orderItem = CreateValidOrderItem();
            orderItem.Status = (ECommerce.RestAPI.Entities.Enums.OrderItemStatus)999;
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Status");
        }

        [Fact]
        public void OrderItem_MissingProductId_ShouldBeInvalid()
        {
            var orderItem = CreateValidOrderItem();
            orderItem.ProductId = Guid.Empty;
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "ProductId");
        }

        [Fact]
        public void OrderItem_MissingOrderId_ShouldBeInvalid()
        {
            var orderItem = CreateValidOrderItem();
            orderItem.OrderId = Guid.Empty;
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "OrderId");
        }

        [Fact]
        public void OrderItem_MissingVendorId_ShouldBeInvalid()
        {
            var orderItem = CreateValidOrderItem();
            orderItem.VendorId = Guid.Empty;
            var validator = new OrderItemValidator();
            var result = validator.Validate(orderItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "VendorId");
        }
    }
}
