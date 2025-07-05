using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class CartTests
    {
        private Cart CreateValidCart() => new Cart { UserId = Guid.NewGuid() };

        [Fact]
        public void Cart_WithValidData_ShouldBeValid()
        {
            var cart = CreateValidCart();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(cart);
            var isValid = Validator.TryValidateObject(cart, context, results, true);
            isValid.Should().BeTrue();
        }

        [Fact]
        public void Cart_MissingUserId_ShouldBeInvalid()
        {
            var cart = new Cart { UserId = Guid.Empty };
            var validator = new ECommerce.RestAPI.Validators.CartValidator();
            var result = validator.Validate(cart);
            result.IsValid.Should().BeFalse();
        }
    }
}
