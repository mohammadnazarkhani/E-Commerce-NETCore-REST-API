using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // ShoppingCartRepository extends the generic Repository to provide CRUD operations for ShoppingCart.
    // It implements IShoppingCartRepository to handle shopping cart specific queries like adding/removing items and checking cart items.
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public ShoppingCartRepository(TondForooshContext context) : base(context) { }

        // Retrieves all items in a specific shopping cart asynchronously.
        public async Task<IEnumerable<CartItem>> GetCartItemsByShoppingCartIdAsync(int shoppingCartId)
        {
            return await _context.CartItems
                .Where(ci => ci.ShoppingCartId == shoppingCartId)  // Filter by shopping cart ID.
                .Include(ci => ci.Product)  // Include product information for each cart item.
                .ToListAsync();  // Executes the query asynchronously and returns the list.
        }

        // Adds an item to the shopping cart.
        public async Task AddCartItemAsync(int shoppingCartId, CartItem cartItem)
        {
            // Check if the cart item already exists in the cart.
            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ShoppingCartId == shoppingCartId && ci.ProductId == cartItem.ProductId);

            if (existingCartItem != null)
            {
                // If the item exists, update the quantity.
                existingCartItem.Quantity += cartItem.Quantity;
            }
            else
            {
                // If the item doesn't exist, add the new cart item.
                cartItem.ShoppingCartId = shoppingCartId;
                await _context.CartItems.AddAsync(cartItem);
            }
        }

        // Removes a specific item from the shopping cart by product ID.
        public async Task RemoveCartItemAsync(int shoppingCartId, int productId)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ShoppingCartId == shoppingCartId && ci.ProductId == productId);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);  // Remove the cart item from the DbSet.
            }
        }

        // Checks if a shopping cart has any items.
        public async Task<bool> HasItemsAsync(int shoppingCartId)
        {
            return await _context.CartItems
                .AnyAsync(ci => ci.ShoppingCartId == shoppingCartId);  // Check if there are any items in the cart.
        }
    }
}
