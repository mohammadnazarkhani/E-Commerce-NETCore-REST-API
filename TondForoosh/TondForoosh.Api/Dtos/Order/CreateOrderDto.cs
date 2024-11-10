using System.ComponentModel.DataAnnotations;
using TondForoosh.Api.Dtos.OrderItem;


namespace TondForoosh.Api.Dtos.Order
{
    public record class CreateOrderDto(
        [Required(ErrorMessage = "TotalPrice is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice must be positive.")]
        decimal TotalPrice,

        [Required(ErrorMessage = "OrderStatus is required.")]
        [StringLength(50, ErrorMessage = "OrderStatus cannot exceed 50 characters.")]
        string OrderStatus,

        [Required(ErrorMessage = "UserId is required.")]
        int UserId,
        DateTime OrderDate,

        [Required(ErrorMessage = "OrderItems are required.")]
        List<CreateOrderItemDto> OrderItems  // List of items in the order
    );
}
