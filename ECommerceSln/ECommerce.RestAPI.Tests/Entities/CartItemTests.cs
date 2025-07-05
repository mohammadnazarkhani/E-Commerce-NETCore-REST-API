using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class CartItemTests
    {
        private CartItem CreateValidCartItem() => new CartItem
        {
            Quantity = 1,
            ProductId = Guid.NewGuid(),
            CartId = Guid.NewGuid()
        };

        [Fact]
        public void CartItem_WithValidData_ShouldBeValid()
        {
            var cartItem = CreateValidCartItem();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(cartItem);
            var isValid = Validator.TryValidateObject(cartItem, context, results, true);
            isValid.Should().BeTrue();
        }

        [Fact]
        public void CartItem_QuantityZeroOrNegative_ShouldBeInvalid()
        {
            var cartItem = CreateValidCartItem();
            cartItem.Quantity = 0;
            var validator = new ECommerce.RestAPI.Validators.CartItemValidator();
            var result = validator.Validate(cartItem);
            result.IsValid.Should().BeFalse();
            cartItem.Quantity = -1;
            result = validator.Validate(cartItem);
            result.IsValid.Should().BeFalse();
        }
    }
}
