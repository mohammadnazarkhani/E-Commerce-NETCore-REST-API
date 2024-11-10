using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.OrderItem
{
    public record class CreateOrderItemDto(
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        int Quantity,

        [Required(ErrorMessage = "ProductId is required.")]
        int ProductId,

        [Required(ErrorMessage = "TotalPrice is required.")]
        decimal TotalPrice
    );
}
