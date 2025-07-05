using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
