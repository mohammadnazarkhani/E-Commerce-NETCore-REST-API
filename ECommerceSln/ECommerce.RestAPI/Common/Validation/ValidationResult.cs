using System;

namespace ECommerce.RestAPI.Common;

/// <summary>
/// Represents the result of a validation opration
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Gets whether the validation was successful
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Gets the validation errors
    /// </summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the ValidationResult class
    /// </summary>
    /// <param name="isValid">Whether the validation was successful</param>
    /// <param name="errors">Validation errors</param>
    public ValidationResult(bool isValid, params string[] errors)
    {
        IsValid = isValid;
        Errors = errors.ToList().AsReadOnly();
    }

    /// <summary>
    /// Creates a successful validation result
    /// </summary>
    /// <returns>Successful validation result</returns>
    public static ValidationResult Success() => new(true);

    /// <summary>
    /// Creates a failed validation result
    /// </summary>
    /// <param name="errors">Validation errors</param>
    /// <returns>Failed validation result</returns>
    public static ValidationResult Failure(params string[] errors) => new(false, errors);
}
