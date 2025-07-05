using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class VendorTests
    {
        private Vendor CreateValidVendor() => new Vendor
        {
            Name = "VendorName",
            Email = "vendor@example.com",
            Address = "123 Main St",
            UserId = Guid.NewGuid()
        };

        [Fact]
        public void Vendor_WithValidData_ShouldBeValid()
        {
            var vendor = CreateValidVendor();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(vendor);
            var isValid = Validator.TryValidateObject(vendor, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Vendor_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var vendor = CreateValidVendor();
            vendor.Name = name;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(vendor);
            var isValid = Validator.TryValidateObject(vendor, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Vendor_NameTooLong_ShouldBeInvalid()
        {
            var vendor = CreateValidVendor();
            vendor.Name = new string('a', 101);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(vendor);
            var isValid = Validator.TryValidateObject(vendor, context, results, true);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData("not-an-email")]
        public void Vendor_InvalidEmail_ShouldBeInvalid(string email)
        {
            var vendor = CreateValidVendor();
            vendor.Email = email;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(vendor);
            var isValid = Validator.TryValidateObject(vendor, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
