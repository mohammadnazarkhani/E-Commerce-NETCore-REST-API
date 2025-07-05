using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid order item status.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required.");

            RuleFor(x => x.VendorId)
                .NotEmpty().WithMessage("VendorId is required.");
        }
    }
}
