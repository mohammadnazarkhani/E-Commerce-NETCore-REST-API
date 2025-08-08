using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateAddressValidator : AbstractValidator<CreateAddressDto>
{
    public CreateAddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.State)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Country)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .MaximumLength(20)
            .Matches(@"^[0-9a-zA-Z-\s]+$").WithMessage("Postal code can only contain letters, numbers, spaces and hyphens");

        RuleFor(x => x.CustomerId)
            .NotEmpty();
    }
}

public class UpdateAddressValidator : AbstractValidator<UpdateAddressDto>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.State)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Country)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .MaximumLength(20)
            .Matches(@"^[0-9a-zA-Z-\s]+$").WithMessage("Postal code can only contain letters, numbers, spaces and hyphens");
    }
}
