using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class VendorValidatorTests
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
            var validator = new VendorValidator();
            var result = validator.Validate(vendor);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Vendor_MissingOrEmptyName_ShouldBeInvalid(string name)
        {
            var vendor = CreateValidVendor();
            vendor.Name = name;
            var validator = new VendorValidator();
            var result = validator.Validate(vendor);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Vendor_NameTooLong_ShouldBeInvalid()
        {
            var vendor = CreateValidVendor();
            vendor.Name = new string('A', 101);
            var validator = new VendorValidator();
            var result = validator.Validate(vendor);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("not-an-email")]
        public void Vendor_InvalidEmail_ShouldBeInvalid(string email)
        {
            var vendor = CreateValidVendor();
            vendor.Email = email;
            var validator = new VendorValidator();
            var result = validator.Validate(vendor);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Email");
        }

        [Fact]
        public void Vendor_AddressTooLong_ShouldBeInvalid()
        {
            var vendor = CreateValidVendor();
            vendor.Address = new string('B', 256);
            var validator = new VendorValidator();
            var result = validator.Validate(vendor);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Address");
        }

        [Fact]
        public void Vendor_MissingUserId_ShouldBeInvalid()
        {
            var vendor = CreateValidVendor();
            vendor.UserId = Guid.Empty;
            var validator = new VendorValidator();
            var result = validator.Validate(vendor);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }
    }
}
