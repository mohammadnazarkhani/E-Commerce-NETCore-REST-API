using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // CartItemRepository extends the generic Repository to provide CRUD operations for CartItem.
    // It implements ICartItemRepository to handle cart item specific queries like adding, removing, and checking products in the cart.
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public CartItemRepository(TondForooshContext context) : base(context) { }

        // Retrieves all items in a specific shopping cart asynchronously.
        public async Task<IEnumerable<CartItem>> GetCartItemsByShoppingCartIdAsync(int shoppingCartId)
        {
            return await _dbSet
                .Where(ci => ci.ShoppingCartId == shoppingCartId)  // Filter by shopping cart ID.
                .Include(ci => ci.Product)  // Include product information.
                .ToListAsync();  // Executes the query and returns the results as a list.
        }

        // Checks if a product already exists in the cart for the specified shopping cart.
        public async Task<bool> ProductExistsInCartAsync(int shoppingCartId, int productId)
        {
            return await _dbSet
                .AnyAsync(ci => ci.ShoppingCartId == shoppingCartId && ci.ProductId == productId);  // Checks if the product exists in the cart.
        }

        // Removes a cart item by its product and shopping cart identifiers.
        public async Task RemoveCartItemAsync(int shoppingCartId, int productId)
        {
            var cartItem = await _dbSet
                .FirstOrDefaultAsync(ci => ci.ShoppingCartId == shoppingCartId && ci.ProductId == productId);  // Find the cart item.

            if (cartItem != null)
            {
                _dbSet.Remove(cartItem);  // Remove the cart item from the DbSet if it exists.
            }
        }
    }
}
