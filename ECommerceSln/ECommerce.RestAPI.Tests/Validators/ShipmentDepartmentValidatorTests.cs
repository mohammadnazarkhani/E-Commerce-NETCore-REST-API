using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class ShipmentDepartmentValidatorTests
    {
        private ShipmentDepartment CreateValidShipmentDepartment() => new ShipmentDepartment { UserId = Guid.NewGuid() };

        [Fact]
        public void ShipmentDepartment_WithValidData_ShouldBeValid()
        {
            var shipment = CreateValidShipmentDepartment();
            var validator = new ShipmentDepartmentValidator();
            var result = validator.Validate(shipment);
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void ShipmentDepartment_MissingUserId_ShouldBeInvalid()
        {
            var shipment = CreateValidShipmentDepartment();
            shipment.UserId = Guid.Empty;
            var validator = new ShipmentDepartmentValidator();
            var result = validator.Validate(shipment);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }
    }
}
