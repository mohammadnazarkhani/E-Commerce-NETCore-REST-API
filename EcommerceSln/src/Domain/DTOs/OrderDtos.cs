namespace Domain.DTOs;

public record OrderResponse(
    Guid Id,
    string OrderNumber,
    string Status,
    decimal TotalAmount,
    DateTime OrderDate,
    DateTime? ShippedDate,
    CustomerResponse Customer,
    AddressResponse ShippingAddress,
    IEnumerable<OrderItemResponse> OrderItems
);

public record CreateOrderRequest(
    Guid CustomerId,
    Guid ShippingAddressId,
    IEnumerable<CreateOrderItemRequest> OrderItems
);

public record UpdateOrderStatusRequest(
    string Status
);
