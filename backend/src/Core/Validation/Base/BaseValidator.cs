using System;
using FluentValidation;

namespace Core.Validation.Base;

public class BaseValidator<T> : AbstractValidator<T>
{
    protected void ApplyRuleSet(string ruleSet, Action rules)
    {
        RuleSet(ruleSet, rules);
        rules(); // Apply rules to default ruleset as well
    }
}
