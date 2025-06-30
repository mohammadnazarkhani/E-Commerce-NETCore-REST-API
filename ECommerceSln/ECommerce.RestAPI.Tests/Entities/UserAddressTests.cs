using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class UserAddressTests
    {
        private UserAddress CreateValidUserAddress() => new UserAddress
        {
            Street = "Main Street",
            BuildingNumber = "12A",
            PostalCode = "1234567890",
            OwnerName = "John Doe",
            PhoneNumber = "0912345678",
            CityId = Guid.NewGuid(),
            UserId = Guid.NewGuid()
        };

        [Fact]
        public void UserAddress_WithValidData_ShouldBeValid()
        {
            var address = CreateValidUserAddress();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            var isValid = Validator.TryValidateObject(address, context, results, true);
            isValid.Should().BeTrue();
        }

        [Fact]
        public void UserAddress_MissingRequiredFields_ShouldBeInvalid()
        {
            // Use reflection to create an uninitialized object (bypassing required property checks)
            var address = (UserAddress)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(UserAddress));
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            var isValid = Validator.TryValidateObject(address, context, results, true);
            isValid.Should().BeFalse();
            results.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("")] // Empty
        public void UserAddress_InvalidStreetLength_ShouldBeInvalid(string street)
        {
            var address = CreateValidUserAddress();
            address.Street = street;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            var isValid = Validator.TryValidateObject(address, context, results, true);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("123456789")] // 9 digits
        [InlineData("123456789012")] // 12 digits
        [InlineData("abcdefghij")] // Not digits
        public void UserAddress_InvalidPostalCode_ShouldBeInvalid(string postalCode)
        {
            var address = CreateValidUserAddress();
            address.PostalCode = postalCode;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            var isValid = Validator.TryValidateObject(address, context, results, true);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("123456789")] // 9 digits
        [InlineData("abcdefghij")] // Not digits
        [InlineData("")] // Empty
        public void UserAddress_InvalidPhoneNumber_ShouldBeInvalid(string phone)
        {
            var address = CreateValidUserAddress();
            address.PhoneNumber = phone;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            var isValid = Validator.TryValidateObject(address, context, results, true);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("not-an-email")] // Invalid email
        public void UserAddress_InvalidEmail_ShouldBeInvalid(string email)
        {
            var address = CreateValidUserAddress();
            address.CostumerEmail = email;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            var isValid = Validator.TryValidateObject(address, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
