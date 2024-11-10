using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.CartItem
{
    public record class CreateCartItemDto(
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        int Quantity,

        [Required(ErrorMessage = "ProductId is required.")]
        int ProductId,

        [Required(ErrorMessage = "ShoppingCartId is required.")]
        int ShoppingCartId
    );
}
