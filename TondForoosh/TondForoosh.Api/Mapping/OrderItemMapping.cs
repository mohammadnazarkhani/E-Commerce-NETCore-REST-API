using TondForoosh.Api.Dtos.OrderItem;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class OrderItemMapping
    {
        // Convert OrderItemDto to OrderItem entity
        public static OrderItem ToEntity(this OrderItemDto orderItemDto)
        {
            return new OrderItem
            {
                Quantity = orderItemDto.Quantity,
                TotalPrice = orderItemDto.TotalPrice,
                ProductId = orderItemDto.ProductId,
                OrderId = orderItemDto.OrderId
            };
        }

        // Convert OrderItem entity to OrderItemDto
        public static OrderItemDto ToDto(this OrderItem orderItem)
        {
            return new OrderItemDto(
                orderItem.Id,
                orderItem.Quantity,
                orderItem.TotalPrice,
                orderItem.ProductId,
                orderItem.Product.Name
            );
        }
    }
}
