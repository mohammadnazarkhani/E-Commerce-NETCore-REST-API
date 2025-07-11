using System;
using System.Linq.Expressions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Repository;

/// <summary>
/// Generic repository interface
/// Provides comprehensive CRUD oprations with async support, filtering, and performance optimizations
/// </summary>
/// <typeparam name="TEntity">Type of entity that CRUD oprations will affect on it. It should be a class that implements IEntity interface directly or indirectly.</typeparam>
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    #region Query Oprations

    /// <summary>
    /// Gets and entity by its identifier with related entitties included
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity if found, null otherwise</returns>
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an entity by its identifier with related entities included
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <param name="includeProperties">Navigation properties to include</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity if found, null otherwise</returns>
    Task<TEntity?> GetByIdAsync(Guid id, string[] includeProperties, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all entites with related entities included
    /// </summary>
    /// <param name="includeProperties">Navigation properties to include</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Collection of all entities</returns>
    Task<IEnumerable<TEntity>> GetAllAsync(string[] includeProperties, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds entites based on a predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Collection of matching entitiese</returns>
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds entites based on a predicate with related entities included
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="includeProperties">Navigation properties to include</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Collection of matching entities</returns>
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string[] includeProperties, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the first entity matching the predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>First matching entity of null</returns>
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a single entity matching the predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Single matching entity or null</returns>
    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    #endregion
    
}
