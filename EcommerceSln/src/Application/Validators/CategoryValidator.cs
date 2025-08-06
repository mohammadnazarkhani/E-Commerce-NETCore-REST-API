using Domain.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Category name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z0-9\s-&]+$").WithMessage("Category name can only contain letters, numbers, spaces, hyphens and ampersands");

        RuleFor(c => c.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
            .When(c => !string.IsNullOrWhiteSpace(c.Description));
    }
}

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Category name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z0-9\s-&]+$").WithMessage("Category name can only contain letters, numbers, spaces, hyphens and ampersands");

        RuleFor(c => c.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
            .When(c => !string.IsNullOrWhiteSpace(c.Description));
    }
}
