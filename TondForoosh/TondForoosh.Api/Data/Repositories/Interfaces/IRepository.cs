using System.Collections.Generic;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // Generic interface for repository with basic CRUD operations for any entity.
    public interface IRepository<T> where T : class
    {
        // Retrieves all entities of type T asynchronously.
        Task<IEnumerable<T>> GetAllAsync();

        // Retrieves an entity by its ID asynchronously.
        Task<T> GetByIdAsync(int id);

        // Adds a new entity of type T to the database asynchronously.
        Task AddAsync(T entity);

        // Updates an existing entity of type T in the database asynchronously.
        Task UpdateAsync(T entity);

        // Deletes an entity by its ID asynchronously.
        Task DeleteAsync(int id);

        // Checks if an entity with the specified ID exists asynchronously.
        Task<bool> ExistsAsync(int id);
    }
}
