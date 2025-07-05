using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class CartItemValidatorTests
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
            var validator = new CartItemValidator();
            var result = validator.Validate(cartItem);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CartItem_QuantityZeroOrNegative_ShouldBeInvalid(int quantity)
        {
            var cartItem = CreateValidCartItem();
            cartItem.Quantity = quantity;
            var validator = new CartItemValidator();
            var result = validator.Validate(cartItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Quantity");
        }

        [Fact]
        public void CartItem_MissingProductId_ShouldBeInvalid()
        {
            var cartItem = CreateValidCartItem();
            cartItem.ProductId = Guid.Empty;
            var validator = new CartItemValidator();
            var result = validator.Validate(cartItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "ProductId");
        }

        [Fact]
        public void CartItem_MissingCartId_ShouldBeInvalid()
        {
            var cartItem = CreateValidCartItem();
            cartItem.CartId = Guid.Empty;
            var validator = new CartItemValidator();
            var result = validator.Validate(cartItem);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "CartId");
        }
    }
}
