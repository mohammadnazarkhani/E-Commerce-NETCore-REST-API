using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.OrderItem
{
    public record class OrderItemDto(
        int Id,

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        int Quantity,

        [Required(ErrorMessage = "TotalPrice is required.")]
        decimal TotalPrice,

        int ProductId,

        string ProductName,
        int OrderId
    );
}
