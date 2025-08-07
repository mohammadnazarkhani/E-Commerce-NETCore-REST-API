namespace Application.DTOs;

public record OrderItemDto(
    Guid Id,
    int Quantity,
    decimal UnitPrice,
    decimal Subtotal,
    Guid OrderId,
    ProductSummaryDto Product
);

public record CreateOrderItemDto(
    Guid ProductId,
    int Quantity
);
