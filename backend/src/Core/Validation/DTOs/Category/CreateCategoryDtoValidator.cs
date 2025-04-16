using System;
using System.Security.Cryptography.X509Certificates;
using Core.DTOs.Category;
using Core.Validation.Base;
using Core.Validation.DTOs.Shared;
using FluentValidation;

namespace Core.Validation.DTOs.Category;

public class CreateCategoryDtoValidator : BaseValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .ValidateName();

        RuleFor(x => x.Description)
            .ValidateDescription();

        RuleFor(x => x.ParentCategoryId)
            .GreaterThan(0)
            .When(x => x.ParentCategoryId.HasValue);
    }
}
