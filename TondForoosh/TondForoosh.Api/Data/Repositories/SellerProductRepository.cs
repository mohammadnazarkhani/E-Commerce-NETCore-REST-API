using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // SellerProductRepository extends the generic Repository to provide CRUD operations for SellerProduct.
    // It implements ISellerProductRepository to handle seller-product specific queries.
    public class SellerProductRepository : Repository<SellerProduct>, ISellerProductRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public SellerProductRepository(TondForooshContext context) : base(context) { }

        // Retrieves all products for a specific seller asynchronously.
        public async Task<IEnumerable<SellerProduct>> GetProductsBySellerIdAsync(int sellerId)
        {
            return await _context.SellerProducts
                .Where(sp => sp.UserId == sellerId)  // Filter by seller (User).
                .Include(sp => sp.Product)  // Include the related product for each SellerProduct.
                .ToListAsync();  // Execute the query asynchronously and return the list.
        }

        // Checks if a specific product is associated with a seller.
        public async Task<bool> IsProductAssociatedWithSellerAsync(int sellerId, int productId)
        {
            return await _context.SellerProducts
                .AnyAsync(sp => sp.UserId == sellerId && sp.ProductId == productId);  // Check if a SellerProduct exists with the given seller and product.
        }
    }
}
