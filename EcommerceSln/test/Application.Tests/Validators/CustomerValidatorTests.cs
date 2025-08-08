using Application.DTOs;
using Application.Validators;
using FluentValidation.TestHelper;

namespace Application.Tests.Validators;

public class CustomerValidatorTests
{
    private readonly CreateCustomerValidator _createValidator;
    private readonly UpdateCustomerValidator _updateValidator;

    public CustomerValidatorTests()
    {
        _createValidator = new CreateCustomerValidator();
        _updateValidator = new UpdateCustomerValidator();
    }

    [Fact]
    public void CreateCustomer_WithValidData_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var dto = new CreateCustomerDto(
            FirstName: "John",
            LastName: "Doe",
            Email: "john.doe@example.com",
            PhoneNumber: "+1-123-456-7890"
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData("john123")] // numbers in name
    [InlineData("John!")] // special character
    [InlineData("John@Doe")] // special character
    public void CreateCustomer_WithInvalidFirstName_ShouldHaveValidationError(string firstName)
    {
        // Arrange
        var dto = new CreateCustomerDto(
            FirstName: firstName,
            LastName: "Doe",
            Email: "john.doe@example.com",
            PhoneNumber: "+1-123-456-7890"
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
             .WithErrorMessage("First name can only contain letters and spaces");
    }

    [Theory]
    [InlineData("notanemail")]
    [InlineData("@example.com")]
    [InlineData("email@")]
    public void CreateCustomer_WithInvalidEmail_ShouldHaveValidationError(string email)
    {
        // Arrange
        var dto = new CreateCustomerDto(
            FirstName: "John",
            LastName: "Doe",
            Email: email,
            PhoneNumber: "+1-123-456-7890"
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData("123abc")] // no plus or hyphen
    [InlineData("+1@123-456-7890")] // invalid character
    [InlineData("+")] // too short
    public void CreateCustomer_WithInvalidPhoneNumber_ShouldHaveValidationError(string phoneNumber)
    {
        // Arrange
        var dto = new CreateCustomerDto(
            FirstName: "John",
            LastName: "Doe",
            Email: "john.doe@example.com",
            PhoneNumber: phoneNumber
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
             .WithErrorMessage("Invalid phone number format");
    }
}
