using TondForoosh.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The ICartItemRepository extends the generic IRepository interface for CartItem.
    // This interface can include additional methods specific to the CartItem entity.
    public interface ICartItemRepository : IRepository<CartItem>
    {
        // Retrieves all items in a specific shopping cart asynchronously.
        Task<IEnumerable<CartItem>> GetCartItemsByShoppingCartIdAsync(int shoppingCartId);

        // Checks if a product already exists in the cart for the specified shopping cart.
        Task<bool> ProductExistsInCartAsync(int shoppingCartId, int productId);

        // Removes a cart item by its product and shopping cart identifiers.
        Task RemoveCartItemAsync(int shoppingCartId, int productId);
    }
}
