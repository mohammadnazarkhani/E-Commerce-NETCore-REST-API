using TondForoosh.Api.Entities;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // Interface for repository of ProductCategory, extends IRepository for basic CRUD operations.
    public interface ICategoryRepository : IRepository<ProductCategory>
    {
        // Retrieves a category by its name asynchronously.
        Task<ProductCategory> GetCategoryByNameAsync(string name);
    }
}
