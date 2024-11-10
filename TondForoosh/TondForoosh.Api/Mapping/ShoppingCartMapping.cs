using TondForoosh.Api.Dtos.ShoppingCart;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class ShoppingCartMapping
    {
        // Convert CreateShoppingCartDto to ShoppingCart entity
        public static ShoppingCart ToEntity(this CreateShoppingCartDto createShoppingCartDto)
        {
            return new ShoppingCart
            {
                UserId = createShoppingCartDto.UserId
            };
        }

        // Convert ShoppingCart entity to ShoppingCartDto
        public static ShoppingCartDto ToDto(this ShoppingCart shoppingCart)
        {
            return new ShoppingCartDto(
                shoppingCart.Id,
                shoppingCart.UserId,
                shoppingCart.CartItems.Select(ci => ci.ToDto()).ToList()
            );
        }
    }
}
