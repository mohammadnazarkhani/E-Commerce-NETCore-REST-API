using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class VendorValidator : AbstractValidator<Vendor>
    {
        public VendorValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Vendor Name is required.")
                .MaximumLength(100).WithMessage("Vendor Name cannot be longer than 100 characters.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Enter a valid email address. Example: example@domain.com");

            RuleFor(v => v.Address)
                .MaximumLength(255).WithMessage("Address cannot be longer than 255 characters.");

            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
