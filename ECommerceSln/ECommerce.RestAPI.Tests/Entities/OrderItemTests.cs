using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class OrderItemTests
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
            var results = new List<ValidationResult>();
            var context = new ValidationContext(orderItem);
            var isValid = Validator.TryValidateObject(orderItem, context, results, true);
            isValid.Should().BeTrue();
        }

        [Fact]
        public void OrderItem_QuantityZeroOrNegative_ShouldBeInvalid()
        {
            var orderItem = CreateValidOrderItem();
            orderItem.Quantity = 0;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(orderItem);
            var isValid = Validator.TryValidateObject(orderItem, context, results, true);
            isValid.Should().BeFalse();
            orderItem.Quantity = -1;
            isValid = Validator.TryValidateObject(orderItem, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
