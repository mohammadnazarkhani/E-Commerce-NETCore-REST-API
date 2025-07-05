using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class CategoryTests
    {
        private Category CreateValidCategory() => new Category { Name = "Electronics" };

        [Fact]
        public void Category_WithValidData_ShouldBeValid()
        {
            var category = CreateValidCategory();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(category);
            var isValid = Validator.TryValidateObject(category, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Category_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var category = CreateValidCategory();
            category.Name = name;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(category);
            var isValid = Validator.TryValidateObject(category, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Category_NameTooLong_ShouldBeInvalid()
        {
            var category = CreateValidCategory();
            category.Name = new string('a', 101);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(category);
            var isValid = Validator.TryValidateObject(category, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
