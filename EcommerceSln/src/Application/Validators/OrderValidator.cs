using Domain.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.CustomerId)
            .NotEmpty().WithMessage("Customer is required");

        RuleFor(o => o.ShippingAddressId)
            .NotEmpty().WithMessage("Shipping address is required");

        RuleFor(o => o.OrderItems)
            .NotEmpty().WithMessage("Order must contain at least one item")
            .Must(items => items.Any()).WithMessage("Order must contain at least one item");

        RuleForEach(o => o.OrderItems).SetValidator(new CreateOrderItemValidator());
    }
}

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemRequest>
{
    public CreateOrderItemValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("Product is required");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0")
            .LessThanOrEqualTo(1000).WithMessage("Quantity cannot exceed 1000 items");
    }
}

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusRequest>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(o => o.Status)
            .NotEmpty().WithMessage("Status is required")
            .Must(status => Enum.TryParse<Domain.Entities.Enums.OrderStatus>(status, true, out _))
            .WithMessage("Invalid order status");
    }
}
