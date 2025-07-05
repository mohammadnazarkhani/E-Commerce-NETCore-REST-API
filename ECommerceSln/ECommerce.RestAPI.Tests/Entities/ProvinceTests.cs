using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class ProvinceTests
    {
        private Province CreateValidProvince() => new Province { Name = "Tehran" };

        [Fact]
        public void Province_WithValidData_ShouldBeValid()
        {
            var province = CreateValidProvince();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(province);
            var isValid = Validator.TryValidateObject(province, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Province_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var province = CreateValidProvince();
            province.Name = name;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(province);
            var isValid = Validator.TryValidateObject(province, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Province_NameTooLong_ShouldBeInvalid()
        {
            var province = CreateValidProvince();
            province.Name = new string('a', 51);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(province);
            var isValid = Validator.TryValidateObject(province, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
