using Application.DTOs;
using Application.Validators;
using FluentValidation.TestHelper;

namespace Application.Tests.Validators;

public class OrderValidatorTests
{
    private readonly CreateOrderValidator _createValidator;
    private readonly UpdateOrderStatusValidator _updateValidator;

    public OrderValidatorTests()
    {
        _createValidator = new CreateOrderValidator();
        _updateValidator = new UpdateOrderStatusValidator();
    }

    [Fact]
    public void CreateOrder_WithValidData_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var dto = new CreateOrderDto(
            CustomerId: Guid.NewGuid(),
            ShippingAddressId: Guid.NewGuid(),
            OrderItems: new List<CreateOrderItemDto>
            {
                new(ProductId: Guid.NewGuid(), Quantity: 1)
            }
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void CreateOrder_WithEmptyOrderItems_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CreateOrderDto(
            CustomerId: Guid.NewGuid(),
            ShippingAddressId: Guid.NewGuid(),
            OrderItems: new List<CreateOrderItemDto>()
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.OrderItems)
             .WithErrorMessage("Order must contain at least one item");
    }

    [Fact]
    public void CreateOrder_WithInvalidOrderItem_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CreateOrderDto(
            CustomerId: Guid.NewGuid(),
            ShippingAddressId: Guid.NewGuid(),
            OrderItems: new List<CreateOrderItemDto>
            {
                new(ProductId: Guid.NewGuid(), Quantity: 0) // Invalid quantity
            }
        );

        // Act
        var result = _createValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor("OrderItems[0].Quantity")
             .WithErrorMessage("Quantity must be greater than 0");
    }

    [Fact]
    public void UpdateOrderStatus_WithInvalidStatus_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new UpdateOrderStatusDto((Domain.Entities.Enums.OrderStatus)999); // Invalid enum value

        // Act
        var result = _updateValidator.TestValidate(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Status)
             .WithErrorMessage("Invalid order status");
    }
}
