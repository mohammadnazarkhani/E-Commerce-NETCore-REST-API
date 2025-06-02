using System;
using FakeEmailGateway.Models.Base;

namespace FakeEmailGateway.Data.Repository;

/// <summary>
/// Generic repository interface for CRUD operations on entities.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : IEntity
{
    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid id);
    /// <summary>
    /// Retrieves all entities of type T.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();
    /// <summary>
    /// Checks if an entity with the specified ID exists.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Guid id);
    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddAsync(T entity);
    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(T entity);
    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);
    /// <summary>
    /// Saves all changes made in this repository to the database.
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
    /// <summary>
    /// Finds entities that match the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
    /// <summary>
    /// Counts the total number of entities in the repository.
    /// </summary>
    /// <returns></returns>
    Task<int> CountAsync();
    /// <summary>
    /// Retrieves a paginated list of entities.
    /// This method is useful for implementing pagination in APIs or UI components.
    /// </summary>
    IQueryable<T> Query { get; }
    /// <summary>
    /// Retrieves a paginated list of entities.
    /// This method is useful for implementing pagination in APIs or UI components.
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
}
