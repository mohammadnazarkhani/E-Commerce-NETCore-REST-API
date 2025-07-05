using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class OrderValidatorTests
    {
        private Order CreateValidOrder() => new Order { Status = ECommerce.RestAPI.Entities.Enums.OrderStatus.Active, UserId = Guid.NewGuid() };

        [Fact]
        public void Order_WithValidData_ShouldBeValid()
        {
            var order = CreateValidOrder();
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Order_InvalidStatus_ShouldBeInvalid()
        {
            var order = CreateValidOrder();
            order.Status = (ECommerce.RestAPI.Entities.Enums.OrderStatus)999;
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Status");
        }

        [Fact]
        public void Order_MissingUserId_ShouldBeInvalid()
        {
            var order = CreateValidOrder();
            order.UserId = Guid.Empty;
            var validator = new OrderValidator();
            var result = validator.Validate(order);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }
    }
}
