using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class UserAddressValidator : AbstractValidator<UserAddress>
    {
        public UserAddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .Length(3, 255).WithMessage("Street must be between 3 and 255 characters.");

            RuleFor(x => x.Alley)
                .MaximumLength(255).WithMessage("Alley cannot be longer than 255 characters.");

            RuleFor(x => x.BuildingNumber)
                .NotEmpty().WithMessage("Building Number is required.")
                .Length(1, 20).WithMessage("Building Number must be between 1 and 20 characters.");

            RuleFor(x => x.Floor)
                .MaximumLength(10).WithMessage("Floor cannot be longer than 10 characters.");

            RuleFor(x => x.UnitNumber)
                .MaximumLength(10).WithMessage("Unit Number cannot be longer than 10 characters.");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal Code is required.")
                .Matches("^\\d{10}$|^\\d{13}$").WithMessage("Invalid Postal Code format. It must be 10 or 13 digits long.")
                .Length(10, 13).WithMessage("Postal Code must be between 10 and 13 digits.");

            RuleFor(x => x.OwnerName)
                .NotEmpty().WithMessage("Owner Name is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches("^\\d{10}$").WithMessage("Invalid phone format. It must be exactly 10 digits long.")
                .MaximumLength(10).WithMessage("Phone Number cannot be longer than 10 digits.");

            RuleFor(x => x.CostumerEmail)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.CostumerEmail)).WithMessage("Invalid email address.")
                .MaximumLength(255).WithMessage("Email cannot be longer than 255 characters.");

            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage("CityId is required.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
