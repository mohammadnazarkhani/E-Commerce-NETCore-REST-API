using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot be longer than 50 characters.");

            RuleFor(x => x.NationalCode)
                .MaximumLength(10).WithMessage("National code cannot be longer than 10 characters.")
                .MinimumLength(10).When(x => !string.IsNullOrEmpty(x.NationalCode)).WithMessage("National code must be exactly 10 characters.");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Invalid user role.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt is required.");
        }
    }
}
