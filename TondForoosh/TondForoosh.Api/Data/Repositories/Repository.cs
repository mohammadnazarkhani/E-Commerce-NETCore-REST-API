using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TondForoosh.Api.Data;
using TondForoosh.Api.Data.Repositories.Interfaces;

namespace TondForoosh.Api.Data.Repositories
{
    // A generic repository class that implements the IRepository interface for CRUD operations on any entity type T.
    // This class can be used for any entity (Product, Category, etc.) as long as it is a class type.
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TondForooshContext _context;  // The DbContext used for interacting with the database. It provides access to the database.
        protected readonly DbSet<T> _dbSet;  // The DbSet associated with the entity type T, used for querying and saving instances of T.

        // Constructor that initializes the DbContext and DbSet.
        // The DbSet is retrieved dynamically based on the entity type T.
        public Repository(TondForooshContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();  // Retrieve the DbSet for the given entity type T. 
        }

        // Asynchronously retrieves all entities of type T from the database.
        // Returns a list of entities of type T.
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();  // Executes the query to retrieve all entities of type T from the database asynchronously.
        }

        // Asynchronously retrieves an entity by its ID.
        // Returns the entity of type T or null if not found.
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);  // Finds and returns the entity with the specified ID from the DbSet asynchronously.
        }

        // Asynchronously adds a new entity of type T to the database.
        // This method is used when inserting a new record into the database.
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);  // Adds the new entity to the DbSet, marking it for insertion into the database.
        }

        // Asynchronously updates an existing entity in the database.
        // This method is used to mark an entity as modified and save changes to the database.
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);  // Marks the entity as modified so that its changes will be persisted to the database.
        }

        // Asynchronously deletes an entity by its ID.
        // First retrieves the entity by ID, then removes it from the DbSet.
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);  // Finds the entity by its ID. If it doesn't exist, returns null.
            if (entity != null)
            {
                _dbSet.Remove(entity);  // Removes the entity from the DbSet, preparing it for deletion from the database.
            }
        }

        // Asynchronously checks if an entity with the specified ID exists in the database.
        // Returns true if an entity with the given ID exists, otherwise false.
        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(e => EF.Property<int>(e, "Id") == id);  // Checks if an entity with the specified ID exists in the DbSet asynchronously.
        }
    }
}
