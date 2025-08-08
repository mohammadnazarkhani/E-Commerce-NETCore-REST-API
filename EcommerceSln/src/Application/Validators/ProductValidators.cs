using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .PrecisionScale(10, 2, false)
            .WithMessage("Price must be greater than 0 with maximum 2 decimal places");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock quantity cannot be negative");

        RuleFor(x => x.SKU)
            .NotEmpty()
            .MaximumLength(50)
            .Matches("^[A-Z0-9-]+$")
            .WithMessage("SKU must contain only uppercase letters, numbers and hyphens");

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .PrecisionScale(10, 2, false)
            .WithMessage("Price must be greater than 0 with maximum 2 decimal places");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock quantity cannot be negative");

        RuleFor(x => x.SKU)
            .NotEmpty()
            .MaximumLength(50)
            .Matches("^[A-Z0-9-]+$")
            .WithMessage("SKU must contain only uppercase letters, numbers and hyphens");

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}
