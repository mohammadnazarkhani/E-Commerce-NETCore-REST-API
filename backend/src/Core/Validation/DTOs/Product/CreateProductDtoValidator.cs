using System;
using System.Data;
using Core.DTOs.Product;
using Core.Validation.Base;
using Core.Validation.DTOs.Shared;
using FluentValidation;

namespace Core.Validation.DTOs.Product;

public class CreateProductDtoValidator : BaseValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .ValidateName();

        RuleFor(x => x.Description)
            .ValidateDescription();

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0);

        RuleFor(x => x.Image)
            .NotNull()
            .Must(file => file.Length > 0 && file.Length <= 5 * 1024 * 1024)
            .WithMessage("Image size must be between 1 byte and 5MB");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0);
    }
}
