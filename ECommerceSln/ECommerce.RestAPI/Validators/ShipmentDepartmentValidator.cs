using ECommerce.RestAPI.Entities;
using FluentValidation;

namespace ECommerce.RestAPI.Validators
{
    public class ShipmentDepartmentValidator : AbstractValidator<ShipmentDepartment>
    {
        public ShipmentDepartmentValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
