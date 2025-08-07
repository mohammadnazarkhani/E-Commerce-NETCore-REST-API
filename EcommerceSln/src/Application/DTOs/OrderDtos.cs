using Domain.Entities.Enums;

namespace Application.DTOs;

public record OrderDto(
    Guid Id,
    string OrderNumber,
    OrderStatus Status,
    decimal TotalAmount,
    DateTime OrderDate,
    DateTime? ShippedDate,
    CustomerSummaryDto Customer,
    AddressDto ShippingAddress,
    ICollection<OrderItemDto> OrderItems
);

public record CreateOrderDto(
    Guid CustomerId,
    Guid ShippingAddressId,
    ICollection<CreateOrderItemDto> OrderItems
);

public record UpdateOrderStatusDto(
    OrderStatus Status
);

public record OrderSummaryDto(
    Guid Id,
    string OrderNumber,
    OrderStatus Status,
    decimal TotalAmount,
    DateTime OrderDate
);
