namespace Domain.DTOs;

public record OrderItemResponse(
    Guid Id,
    int Quantity,
    decimal UnitPrice,
    decimal Subtotal,
    ProductResponse Product
);

public record CreateOrderItemRequest(
    Guid ProductId,
    int Quantity
);
