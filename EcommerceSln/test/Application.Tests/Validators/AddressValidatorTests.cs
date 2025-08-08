using Application.DTOs;
using Application.Validators;
using FluentValidation.TestHelper;

namespace Application.Tests.Validators;

public class AddressValidatorTests
{
    private readonly CreateAddressValidator _createValidator;
    private readonly UpdateAddressValidator _updateValidator;

    public AddressValidatorTests()
    {
        _createValidator = new CreateAddressValidator();
        _updateValidator = new UpdateAddressValidator();
    }

    [Fact]
    public void CreateAddress_WithValidData_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var dto = new CreateAddressDto(
            Street: "123 Main St",
            City: "New York",
            State: "NY",
            Country: "USA",
            PostalCode: "10001",
            IsDefault: true,
            CustomerId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void CreateAddress_WithInvalidStreet_ShouldHaveValidationError(string street)
    {
        // Arrange
        var dto = new CreateAddressDto(
            Street: street,
            City: "New York",
            State: "NY",
            Country: "USA",
            PostalCode: "10001",
            IsDefault: true,
            CustomerId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Street);
    }

    [Fact]
    public void CreateAddress_WithInvalidPostalCode_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CreateAddressDto(
            Street: "123 Main St",
            City: "New York",
            State: "NY",
            Country: "USA",
            PostalCode: "!@#$%",
            IsDefault: true,
            CustomerId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PostalCode)
             .WithErrorMessage("Postal code can only contain letters, numbers, spaces and hyphens");
    }

    [Fact]
    public void CreateAddress_WithEmptyCustomerId_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CreateAddressDto(
            Street: "123 Main St",
            City: "New York",
            State: "NY",
            Country: "USA",
            PostalCode: "10001",
            IsDefault: true,
            CustomerId: Guid.Empty
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CustomerId);
    }
}
