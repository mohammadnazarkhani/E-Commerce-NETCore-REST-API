using TondForoosh.Api.Dtos.CartItem;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class CartItemMapping
    {
        public static CartItem ToEntity(this CreateCartItemDto createCartItemDto)
        {
            return new CartItem
            {
                Quantity = createCartItemDto.Quantity,
                ProductId = createCartItemDto.ProductId,
                ShoppingCartId = createCartItemDto.ShoppingCartId
            };
        }

        public static CartItemDto ToDto(this CartItem cartItem)
        {
            return new CartItemDto(
                cartItem.Id,
                cartItem.Quantity,
                cartItem.Product.Price, // Correct data type for Price
                cartItem.Product.Name
            );
        }

    }
}
