using TondForoosh.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The IShoppingCartRepository extends the generic IRepository interface for ShoppingCart.
    // This interface can include additional methods specific to the ShoppingCart entity.
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        // Retrieves all items in a specific shopping cart asynchronously.
        Task<IEnumerable<CartItem>> GetCartItemsByShoppingCartIdAsync(int shoppingCartId);

        // Adds an item to the shopping cart.
        Task AddCartItemAsync(int shoppingCartId, CartItem cartItem);

        // Removes a specific item from the shopping cart.
        Task RemoveCartItemAsync(int shoppingCartId, int productId);

        // Checks if a shopping cart has any items.
        Task<bool> HasItemsAsync(int shoppingCartId);
    }
}
