using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class CityValidatorTests
    {
        private City CreateValidCity() => new City { Name = "Tehran", ProvinceId = Guid.NewGuid() };

        [Fact]
        public void City_WithValidData_ShouldBeValid()
        {
            var city = CreateValidCity();
            var validator = new CityValidator();
            var result = validator.Validate(city);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void City_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var city = CreateValidCity();
            city.Name = name;
            var validator = new CityValidator();
            var result = validator.Validate(city);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void City_NameTooShort_ShouldBeInvalid()
        {
            var city = CreateValidCity();
            city.Name = "A";
            var validator = new CityValidator();
            var result = validator.Validate(city);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void City_NameTooLong_ShouldBeInvalid()
        {
            var city = CreateValidCity();
            city.Name = new string('B', 256);
            var validator = new CityValidator();
            var result = validator.Validate(city);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void City_MissingProvinceId_ShouldBeInvalid()
        {
            var city = CreateValidCity();
            city.ProvinceId = Guid.Empty;
            var validator = new CityValidator();
            var result = validator.Validate(city);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "ProvinceId");
        }
    }
}
