using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class CityTests
    {
        private City CreateValidCity() => new City { Name = "Tehran", ProvinceId = Guid.NewGuid() };

        [Fact]
        public void City_WithValidData_ShouldBeValid()
        {
            var city = CreateValidCity();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(city);
            var isValid = Validator.TryValidateObject(city, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void City_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var city = CreateValidCity();
            city.Name = name;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(city);
            var isValid = Validator.TryValidateObject(city, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void City_NameTooShortOrTooLong_ShouldBeInvalid()
        {
            var city = CreateValidCity();
            city.Name = "A";
            var results = new List<ValidationResult>();
            var context = new ValidationContext(city);
            var isValid = Validator.TryValidateObject(city, context, results, true);
            isValid.Should().BeFalse();
            city.Name = new string('b', 256);
            isValid = Validator.TryValidateObject(city, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void City_MissingProvinceId_ShouldBeInvalid()
        {
            var city = CreateValidCity();
            city.ProvinceId = Guid.Empty;
            var validator = new ECommerce.RestAPI.Validators.CityValidator();
            var result = validator.Validate(city);
            result.IsValid.Should().BeFalse();
        }
    }
}
