using System;
using Core.Common.Constants;
using FluentValidation;

namespace Core.Validation.DTOs.Shared;

public static class SharedValidationRules
{
    public static IRuleBuilderOptions<T, string?> ValidateName<T>(this IRuleBuilder<T, string?> ruleBuilder)
        => ruleBuilder.MaximumLength(ValidationConstants.Shared.MaxNameLength);

    public static IRuleBuilderOptions<T, string?> ValidateDescription<T>(this IRuleBuilder<T, string?> ruleBuilder)
        => ruleBuilder.MaximumLength(ValidationConstants.Shared.MaxDescriptionLength);
}
