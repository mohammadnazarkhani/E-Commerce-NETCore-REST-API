using System;
using Core.DTOs.Category;
using Core.Validation.Base;
using FluentValidation;

namespace Core.Validation.DTOs.Category;

public class UpdateCategoryDtoValidator : BaseValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => x.Name != null);

        RuleFor(x => x.Description)
            .MaximumLength(2000)
            .When(x => x.Description != null);

        RuleFor(x => x.ParentCategoryId)
            .GreaterThan(0)
            .When(x => x.ParentCategoryId.HasValue);
    }
}
