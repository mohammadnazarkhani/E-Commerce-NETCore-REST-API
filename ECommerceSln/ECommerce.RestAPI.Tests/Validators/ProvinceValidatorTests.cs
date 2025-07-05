using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class ProvinceValidatorTests
    {
        private Province CreateValidProvince() => new Province { Name = "Tehran" };

        [Fact]
        public void Province_WithValidData_ShouldBeValid()
        {
            var province = CreateValidProvince();
            var validator = new ProvinceValidator();
            var result = validator.Validate(province);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Province_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var province = CreateValidProvince();
            province.Name = name;
            var validator = new ProvinceValidator();
            var result = validator.Validate(province);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Province_NameTooShort_ShouldBeInvalid()
        {
            var province = CreateValidProvince();
            province.Name = "A";
            var validator = new ProvinceValidator();
            var result = validator.Validate(province);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Province_NameTooLong_ShouldBeInvalid()
        {
            var province = CreateValidProvince();
            province.Name = new string('B', 51);
            var validator = new ProvinceValidator();
            var result = validator.Validate(province);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Province_NameWithInvalidCharacters_ShouldBeInvalid()
        {
            var province = CreateValidProvince();
            province.Name = "Tehran123!";
            var validator = new ProvinceValidator();
            var result = validator.Validate(province);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }
    }
}
