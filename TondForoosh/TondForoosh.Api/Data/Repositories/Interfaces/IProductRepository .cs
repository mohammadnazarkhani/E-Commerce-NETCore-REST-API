using TondForoosh.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The IProductRepository extends the generic IRepository interface for Product.
    // This interface can include additional methods specific to the Product entity.
    public interface IProductRepository : IRepository<Product>
    {
        // Example method to get products by a category asynchronously.
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);

        // Example method to search products by name asynchronously.
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string name);

        // Example method to get products by price range asynchronously.
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}
