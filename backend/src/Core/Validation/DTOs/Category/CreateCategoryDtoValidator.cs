using System;
using System.Security.Cryptography.X509Certificates;
using Core.DTOs.Category;
using Core.Validation.Base;
using FluentValidation;

namespace Core.Validation.DTOs.Category;

public class CreateCategoryDtoValidator : BaseValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .MaximumLength(2000);

        RuleFor(x => x.ParentCategoryId)
            .GreaterThan(0)
            .When(x => x.ParentCategoryId.HasValue);
    }
}
