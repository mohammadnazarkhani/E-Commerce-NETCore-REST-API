using TondForoosh.Api.Dtos.OrderItem;

namespace TondForoosh.Api.Dtos.Order
{
    public record class OrderDetailDto(
        int Id,
        decimal TotalPrice,
        DateTime OrderDate,
        DateTime? DeliveryDate,
        string OrderStatus,
        string Username,
        List<OrderItemDto> OrderItems  // List of items in the order
    );
}
