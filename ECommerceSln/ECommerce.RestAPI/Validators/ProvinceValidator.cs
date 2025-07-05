using FluentValidation;
using ECommerce.RestAPI.Entities;

namespace ECommerce.RestAPI.Validators
{
    public class ProvinceValidator : AbstractValidator<Province>
    {
        public ProvinceValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Province name is required.")
                .Length(2, 50)
                .WithMessage("Province name must be between 2 and 50 characters")
                .Matches("^[\\p{L}\\s-]+$")
                .WithMessage("Province name can only contain letters, spaces, and hyphens")
                .MaximumLength(50)
                .WithMessage("Province name cannot be longer than 50 characters.");
        }
    }
}