using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class CartValidatorTests
    {
        private Cart CreateValidCart() => new Cart { UserId = Guid.NewGuid() };

        [Fact]
        public void Cart_WithValidData_ShouldBeValid()
        {
            var cart = CreateValidCart();
            var validator = new CartValidator();
            var result = validator.Validate(cart);
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Cart_MissingUserId_ShouldBeInvalid()
        {
            var cart = new Cart { UserId = Guid.Empty };
            var validator = new CartValidator();
            var result = validator.Validate(cart);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }
    }
}
