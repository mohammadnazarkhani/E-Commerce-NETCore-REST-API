using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class CategoryValidatorTests
    {
        private Category CreateValidCategory() => new Category { Name = "Electronics" };

        [Fact]
        public void Category_WithValidData_ShouldBeValid()
        {
            var category = CreateValidCategory();
            var validator = new CategoryValidator();
            var result = validator.Validate(category);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Category_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var category = CreateValidCategory();
            category.Name = name;
            var validator = new CategoryValidator();
            var result = validator.Validate(category);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Category_NameTooLong_ShouldBeInvalid()
        {
            var category = CreateValidCategory();
            category.Name = new string('A', 101);
            var validator = new CategoryValidator();
            var result = validator.Validate(category);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }
    }
}
