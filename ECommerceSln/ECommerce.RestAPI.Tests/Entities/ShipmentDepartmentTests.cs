using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class ShipmentDepartmentTests
    {
        private ShipmentDepartment CreateValidShipmentDepartment() => new ShipmentDepartment { UserId = Guid.NewGuid() };

        [Fact]
        public void ShipmentDepartment_WithValidData_ShouldBeValid()
        {
            var shipment = CreateValidShipmentDepartment();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(shipment);
            var isValid = Validator.TryValidateObject(shipment, context, results, true);
            isValid.Should().BeTrue();
        }
    }
}
