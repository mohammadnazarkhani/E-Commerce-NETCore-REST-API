using Domain.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateAddressValidator : AbstractValidator<CreateAddressRequest>
{
    public CreateAddressValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(100).WithMessage("Street cannot exceed 100 characters");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("City is required")
            .Length(2, 50).WithMessage("City must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z\s-']+$").WithMessage("City can only contain letters, spaces, hyphens and apostrophes");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("State is required")
            .Length(2, 50).WithMessage("State must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z\s-']+$").WithMessage("State can only contain letters, spaces, hyphens and apostrophes");

        RuleFor(a => a.Country)
            .NotEmpty().WithMessage("Country is required")
            .Length(2, 50).WithMessage("Country must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z\s-']+$").WithMessage("Country can only contain letters, spaces, hyphens and apostrophes");

        RuleFor(a => a.PostalCode)
            .NotEmpty().WithMessage("Postal code is required")
            .Length(4, 10).WithMessage("Postal code must be between 4 and 10 characters")
            .Matches(@"^[A-Za-z0-9-\s]+$").WithMessage("Postal code can only contain letters, numbers, spaces and hyphens");
    }
}

public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
{
    public UpdateAddressValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(100).WithMessage("Street cannot exceed 100 characters");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("City is required")
            .Length(2, 50).WithMessage("City must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z\s-']+$").WithMessage("City can only contain letters, spaces, hyphens and apostrophes");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("State is required")
            .Length(2, 50).WithMessage("State must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z\s-']+$").WithMessage("State can only contain letters, spaces, hyphens and apostrophes");

        RuleFor(a => a.Country)
            .NotEmpty().WithMessage("Country is required")
            .Length(2, 50).WithMessage("Country must be between 2 and 50 characters")
            .Matches(@"^[A-Za-z\s-']+$").WithMessage("Country can only contain letters, spaces, hyphens and apostrophes");

        RuleFor(a => a.PostalCode)
            .NotEmpty().WithMessage("Postal code is required")
            .Length(4, 10).WithMessage("Postal code must be between 4 and 10 characters")
            .Matches(@"^[A-Za-z0-9-\s]+$").WithMessage("Postal code can only contain letters, numbers, spaces and hyphens");
    }
}
