using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is required.")
                .Length(2, 255).WithMessage("City name must be between 2 and 255 characters.");

            RuleFor(x => x.ProvinceId)
                .NotEmpty().WithMessage("ProvinceId is required.");
        }
    }
}
