using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class PaymentTests
    {
        private Payment CreateValidPayment() => new Payment
        {
            Method = ECommerce.RestAPI.Entities.Enums.PaymentMethod.CreditCard,
            Status = ECommerce.RestAPI.Entities.Enums.PaymentStatus.Completed,
            UserId = Guid.NewGuid(),
            OrderId = Guid.NewGuid()
        };

        [Fact]
        public void Payment_WithValidData_ShouldBeValid()
        {
            var payment = CreateValidPayment();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(payment);
            var isValid = Validator.TryValidateObject(payment, context, results, true);
            isValid.Should().BeTrue();
        }

        [Fact]
        public void Payment_MissingUserId_ShouldBeInvalid()
        {
            var payment = CreateValidPayment();
            payment.UserId = Guid.Empty;
            var validator = new ECommerce.RestAPI.Validators.PaymentValidator();
            var result = validator.Validate(payment);
            result.IsValid.Should().BeFalse();
        }
    }
}
