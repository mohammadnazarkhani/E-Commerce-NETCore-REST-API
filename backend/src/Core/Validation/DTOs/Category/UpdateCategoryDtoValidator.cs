using System;
using Core.DTOs.Category;
using Core.Validation.Base;
using Core.Validation.DTOs.Shared;
using FluentValidation;

namespace Core.Validation.DTOs.Category;

public class UpdateCategoryDtoValidator : BaseValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .ValidateName()
            .When(x => x.Name != null);

        RuleFor(x => x.Description)
            .ValidateDescription()
            .When(x => x.Description != null);

        RuleFor(x => x.ParentCategoryId)
            .GreaterThan(0)
            .When(x => x.ParentCategoryId.HasValue);
    }
}
