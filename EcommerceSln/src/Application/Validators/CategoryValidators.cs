using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50)
            .Matches("^[a-zA-Z0-9 -&]+$").WithMessage("Category name can only contain letters, numbers, spaces, hyphens and ampersands");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50)
            .Matches("^[a-zA-Z0-9 -&]+$").WithMessage("Category name can only contain letters, numbers, spaces, hyphens and ampersands");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}
