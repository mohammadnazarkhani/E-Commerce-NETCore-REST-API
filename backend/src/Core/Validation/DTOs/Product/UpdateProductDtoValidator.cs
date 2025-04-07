using System;
using System.Data;
using Core.DTOs.Product;
using Core.Validation.Base;
using Core.Validation.DTOs.Shared;
using FluentValidation;

namespace Core.Validation.DTOs.Product;

public class UpdateProductDtoValidator : BaseValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .ValidateName()
            .When(x => x.Name != null);

        RuleFor(x => x.Description)
            .ValidateDescription()
            .When(x => x.Description != null);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .When(x => x.Price.HasValue);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .When(x => x.CategoryId.HasValue);

        RuleFor(x => x.Image)
            .Must(file => file == null || (file.Length > 0 && file.Length <= 5 * 1024 * 1024))
            .WithMessage("Image size must be between 1 byte and 5MB")
            .When(x => x.Image != null);

        RuleFor(x => x.StockQuantity)
            .GreaterThan(0)
            .When(x => x.StockQuantity.HasValue);
    }
}
