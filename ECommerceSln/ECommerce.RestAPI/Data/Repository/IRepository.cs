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

    #region Pagination and Ordering

    /// <summary>
    /// Gets paginated results with optional filtering and ordering
    /// </summary>
    /// <param name="pageNumber">Page number (1-based)</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="predicate">Optional filter expression</param>
    /// <param name="orderBy">Optional ordering expression</param>
    /// <param name="includeProperties">Navigation properties to include</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated result set</returns>
    Task<(IEnumerable<TEntity> Data, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string[]? includeProperties = null,
        CancellationToken cancellationToken = default
    );

    #endregion

    #region Aggregation Oprations

    /// <summary>
    /// Counts all entities
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Total count of entities</returns>
    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Count entities matching a predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Count of mathing entities</returns>
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if any entity matches the predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if any entity matches, false otherwise</returns>
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if all entites match the predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if all entities match, false otherwise</returns>
    Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    #endregion

    #region Command Oprations

    /// <summary>
    /// Adds a new entity
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Added entity</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds multiple entities
    /// </summary>
    /// <param name="entities">Entities to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates and existing entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="cancellationToken">Cancellatioin token</param>
    /// <returns>Updated entity</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates multiple entities
    /// </summary>
    /// <param name="entitites">Entities to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>ATask representing the opration</returns>
    Task UpdateRangeAsync(IEnumerable<TEntity> entitites, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes an entitiy
    /// </summary>
    /// <param name="entity">Entity to remove</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes an entity by its identifier
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes multiple entities
    /// </summary>
    /// <param name="entities">Entities to remove</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes entities matching a predicate
    /// </summary>
    /// <param name="predicate">Filter expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of entities removed</returns>
    Task<int> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    #endregion

    #region Advanced Oprations

    /// <summary>
    /// Executes a raw SQL query and returns entities
    /// </summary>
    /// <param name="sql">SQL query</param>
    /// <param name="parameters">Query parameters</param>
    /// <param name="cancellationTOken">Cancellation token</param>
    /// <returns>Cancellation of entities</returns>
    Task<IEnumerable<TEntity>> ExecuteQueryAsync(string sql, object[] parameters, CancellationToken cancellationTOken);

    /// <summary>
    /// Executes a raw SQL command
    /// </summary>
    /// <param name="sql">SQL command</param>
    /// <param name="parameters">Command parameters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of affected rows</returns>
    Task<int> ExecuteComandAsync(string sql, object[] parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reloads an entity from the database
    /// </summary>
    /// <param name="entity">Entity to reload</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task ReloadAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Detaches an entity from the context
    /// </summary>
    /// <param name="entitiy">Entity to detach</param>
    void Detach(TEntity entitiy);

    /// <summary>
    /// Attaches an entity to the context
    /// </summary>
    /// <param name="entity">Entity to attach</param>
    void Attach(TEntity entity);

    #endregion

    #region Unit of Work Pattern Support

    /// <summary>
    /// Saves all changes to the database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of entities affected</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Begins a database transaction
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Database transaction</returns>
    Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default);

    #endregion

    #region Query Building

    /// <summary>
    /// Gets a queryable interface for advanced querying
    /// </summary>
    /// <returns>IQueryable for the entity type</returns>
    IQueryable<TEntity> AsQueryable();

    /// <summary>
    /// Gets a queryable interface with tracking disabled for read-only oprations
    /// </summary>
    /// <returns>IQueryable for the entity type with no tracking</returns>
    IQueryable<TEntity> AsNoTracking();

    #endregion
}
