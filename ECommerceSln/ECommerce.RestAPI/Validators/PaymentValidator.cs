using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Method)
                .IsInEnum().WithMessage("Invalid payment method.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid payment status.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required.");
        }
    }
}
