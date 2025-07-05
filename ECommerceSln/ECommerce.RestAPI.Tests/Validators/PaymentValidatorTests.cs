using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class PaymentValidatorTests
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
            var validator = new PaymentValidator();
            var result = validator.Validate(payment);
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Payment_InvalidMethod_ShouldBeInvalid()
        {
            var payment = CreateValidPayment();
            payment.Method = (ECommerce.RestAPI.Entities.Enums.PaymentMethod)999;
            var validator = new PaymentValidator();
            var result = validator.Validate(payment);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Method");
        }

        [Fact]
        public void Payment_InvalidStatus_ShouldBeInvalid()
        {
            var payment = CreateValidPayment();
            payment.Status = (ECommerce.RestAPI.Entities.Enums.PaymentStatus)999;
            var validator = new PaymentValidator();
            var result = validator.Validate(payment);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Status");
        }

        [Fact]
        public void Payment_MissingUserId_ShouldBeInvalid()
        {
            var payment = CreateValidPayment();
            payment.UserId = Guid.Empty;
            var validator = new PaymentValidator();
            var result = validator.Validate(payment);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }

        [Fact]
        public void Payment_MissingOrderId_ShouldBeInvalid()
        {
            var payment = CreateValidPayment();
            payment.OrderId = Guid.Empty;
            var validator = new PaymentValidator();
            var result = validator.Validate(payment);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "OrderId");
        }
    }
}
