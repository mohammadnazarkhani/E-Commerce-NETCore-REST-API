using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // ProductRepository extends the generic Repository to provide CRUD operations for Product.
    // It implements IProductRepository to handle product-specific queries like searching by name, filtering by category, etc.
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public ProductRepository(TondForooshContext context) : base(context) { }

        // Retrieves products by category asynchronously.
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(p => p.ProductCategoryId == categoryId)  // Filter products by category ID.
                .ToListAsync();  // Return the matching products as a list.
        }

        // Searches products by name asynchronously.
        public async Task<IEnumerable<Product>> SearchProductsByNameAsync(string name)
        {
            return await _dbSet
                .Where(p => p.Name.Contains(name))  // Filter products by name (partial match).
                .ToListAsync();  // Return the matching products as a list.
        }

        // Retrieves products within a price range asynchronously.
        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)  // Filter products by price range.
                .ToListAsync();  // Return the matching products as a list.
        }
    }
}
