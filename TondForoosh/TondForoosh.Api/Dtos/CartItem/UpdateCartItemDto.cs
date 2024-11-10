using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.CartItem
{
    public record class UpdateCartItemDto(
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        int Quantity
    );
}
