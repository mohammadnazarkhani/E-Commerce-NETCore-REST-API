using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.CartId)
                .NotEmpty().WithMessage("CartId is required.");
        }
    }
}
