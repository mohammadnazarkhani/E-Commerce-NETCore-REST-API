using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class ProductValidatorTests
    {
        private Product CreateValidProduct() => new Product
        {
            Name = "ProductName",
            Description = "A valid description.",
            Price = 10.5m,
            StockQuantity = 5,
            CategoryId = Guid.NewGuid(),
            VendorId = Guid.NewGuid()
        };

        [Fact]
        public void Product_WithValidData_ShouldBeValid()
        {
            var product = CreateValidProduct();
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Product_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var product = CreateValidProduct();
            product.Name = name;
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Product_NameTooLong_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.Name = new string('A', 101);
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Product_DescriptionTooLong_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.Description = new string('B', 1001);
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Description");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Product_PriceZeroOrNegative_ShouldBeInvalid(decimal price)
        {
            var product = CreateValidProduct();
            product.Price = price;
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Price");
        }

        [Fact]
        public void Product_StockQuantityNegative_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.StockQuantity = -1;
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "StockQuantity");
        }

        [Fact]
        public void Product_MissingCategoryId_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.CategoryId = Guid.Empty;
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "CategoryId");
        }

        [Fact]
        public void Product_MissingVendorId_ShouldBeInvalid()
        {
            var product = CreateValidProduct();
            product.VendorId = Guid.Empty;
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "VendorId");
        }
    }
}
