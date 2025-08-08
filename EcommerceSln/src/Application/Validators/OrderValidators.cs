using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty();

        RuleFor(x => x.ShippingAddressId)
            .NotEmpty();

        RuleFor(x => x.OrderItems)
            .NotEmpty()
            .WithMessage("Order must contain at least one item");

        RuleForEach(x => x.OrderItems)
            .SetValidator(new CreateOrderItemValidator());
    }
}

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusDto>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Invalid order status");
    }
}
