using Application.DTOs;
using Application.Validators;
using FluentValidation.TestHelper;

namespace Application.Tests.Validators;

public class ProductValidatorTests
{
    private readonly CreateProductValidator _createValidator;
    private readonly UpdateProductValidator _updateValidator;

    public ProductValidatorTests()
    {
        _createValidator = new CreateProductValidator();
        _updateValidator = new UpdateProductValidator();
    }

    [Fact]
    public void CreateProduct_WithValidData_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var dto = new CreateProductDto(
            Name: "Test Product",
            Description: "Test Description",
            Price: 99.99m,
            StockQuantity: 10,
            SKU: "TEST-123",
            IsAvailable: true,
            CategoryId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CreateProduct_WithInvalidPrice_ShouldHaveValidationError(decimal price)
    {
        // Arrange
        var dto = new CreateProductDto(
            Name: "Test Product",
            Description: "Test Description",
            Price: price,
            StockQuantity: 10,
            SKU: "TEST-123",
            IsAvailable: true,
            CategoryId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }

    [Theory]
    [InlineData("test-123")] // lowercase
    [InlineData("TEST 123")] // space
    [InlineData("TEST_123")] // underscore
    public void CreateProduct_WithInvalidSKU_ShouldHaveValidationError(string sku)
    {
        // Arrange
        var dto = new CreateProductDto(
            Name: "Test Product",
            Description: "Test Description",
            Price: 99.99m,
            StockQuantity: 10,
            SKU: sku,
            IsAvailable: true,
            CategoryId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SKU)
             .WithErrorMessage("SKU must contain only uppercase letters, numbers and hyphens");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    public void CreateProduct_WithNegativeStock_ShouldHaveValidationError(int stockQuantity)
    {
        // Arrange
        var dto = new CreateProductDto(
            Name: "Test Product",
            Description: "Test Description",
            Price: 99.99m,
            StockQuantity: stockQuantity,
            SKU: "TEST-123",
            IsAvailable: true,
            CategoryId: Guid.NewGuid()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.StockQuantity)
             .WithErrorMessage("Stock quantity cannot be negative");
    }
}
