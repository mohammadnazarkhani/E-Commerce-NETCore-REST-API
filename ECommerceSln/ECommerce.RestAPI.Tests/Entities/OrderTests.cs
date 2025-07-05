using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class OrderTests
    {
        private Order CreateValidOrder() => new Order
        {
            Status = ECommerce.RestAPI.Entities.Enums.OrderStatus.Active,
            UserId = Guid.NewGuid()
        };

        [Fact]
        public void Order_WithValidData_ShouldBeValid()
        {
            var order = CreateValidOrder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(order);
            var isValid = Validator.TryValidateObject(order, context, results, true);
            isValid.Should().BeTrue();
        }

        [Fact]
        public void Order_MissingUserId_ShouldBeInvalid()
        {
            var order = CreateValidOrder();
            order.UserId = Guid.Empty;
            var validator = new ECommerce.RestAPI.Validators.OrderValidator();
            var result = validator.Validate(order);
            result.IsValid.Should().BeFalse();
        }
    }
}
