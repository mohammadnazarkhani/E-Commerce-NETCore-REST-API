using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // CategoryRepository extends the generic Repository to provide CRUD operations for ProductCategory.
    // It implements ICategoryRepository to handle category-specific queries like getting category by name.
    public class CategoryRepository : Repository<ProductCategory>, ICategoryRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public CategoryRepository(TondForooshContext context) : base(context) { }

        // Retrieves a category by its name asynchronously.
        public async Task<ProductCategory> GetCategoryByNameAsync(string name)
        {
            // Use the inherited _dbSet to filter categories by name.
            // _dbSet provides the DbSet for the ProductCategory entity type.
            return await _dbSet
                .Where(c => c.Title == name)  // Filter categories by name.
                .FirstOrDefaultAsync();  // Return the first category that matches or null if not found.
        }
    }
}
