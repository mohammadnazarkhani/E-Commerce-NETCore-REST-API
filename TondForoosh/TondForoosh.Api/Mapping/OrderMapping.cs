using TondForoosh.Api.Dtos.Order;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class OrderMapping
    {
        // Convert CreateOrderDto to Order entity
        public static Order ToEntity(this CreateOrderDto createOrderDto)
        {
            return new Order
            {
                TotalPrice = createOrderDto.TotalPrice,
                OrderDate = createOrderDto.OrderDate,
                OrderStatus = createOrderDto.OrderStatus,
                UserId = createOrderDto.UserId
            };
        }

        // Convert Order entity to OrderDto
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto(
                order.Id,
                order.TotalPrice,
                order.OrderDate,
                order.OrderStatus,
                order.UserId
            );
        }

        // Convert Order entity to OrderDetailDto (for detailed order view)
        public static OrderDetailDto ToDetailDto(this Order order)
        {
            var orderItemsDto = order.OrderItems.Select(oi => oi.ToDto()).ToList();

            return new OrderDetailDto(
                order.Id,
                order.TotalPrice,
                order.OrderDate,
                order.DeliveryDate,
                order.OrderStatus,
                order.UserId,
                order.User.Username,
                orderItemsDto
            );
        }
    }
}
