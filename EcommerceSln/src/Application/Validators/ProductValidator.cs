using Domain.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Product description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .PrecisionScale(10, 2, false).WithMessage("Price cannot have more than 2 decimal places");

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative");

        RuleFor(p => p.SKU)
            .NotEmpty().WithMessage("SKU is required")
            .Length(5, 20).WithMessage("SKU must be between 5 and 20 characters")
            .Matches(@"^[A-Za-z0-9-]+$").WithMessage("SKU can only contain letters, numbers, and hyphens");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category is required");
    }
}

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Product description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .PrecisionScale(10, 2, false).WithMessage("Price cannot have more than 2 decimal places");

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative");

        RuleFor(p => p.SKU)
            .NotEmpty().WithMessage("SKU is required")
            .Length(5, 20).WithMessage("SKU must be between 5 and 20 characters")
            .Matches(@"^[A-Za-z0-9-]+$").WithMessage("SKU can only contain letters, numbers, and hyphens");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category is required");
    }
}
