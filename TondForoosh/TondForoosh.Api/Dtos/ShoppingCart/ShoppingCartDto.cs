using TondForoosh.Api.Dtos.CartItem;

namespace TondForoosh.Api.Dtos.ShoppingCart
{
    public record class ShoppingCartDto(
        int Id,
        List<CartItemDto> CartItems  // List of items in the shopping cart
    );
}
