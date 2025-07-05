using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class ProductTests
    {
        private Product CreateValidProduct() => new Product
        {
            Name = "ProductName",
            Price = 10.5m,
            StockQuantity = 5,
            CategoryId = Guid.NewGuid(),
            VendorId = Guid.NewGuid()
        };

        [Fact]
        public void Product_WithValidData_ShouldBeValid()
        {
            var product = CreateValidProduct();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(product);
            var isValid = Validator.TryValidateObject(product, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Product_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var product = CreateValidProduct();
            product.Name = name;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(product);
            var isValid = Validator.TryValidateObject(product, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Product_NameTooLong_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.Name = new string('a', 101);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(product);
            var isValid = Validator.TryValidateObject(product, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Product_NegativePrice_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.Price = -1;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(product);
            var isValid = Validator.TryValidateObject(product, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
