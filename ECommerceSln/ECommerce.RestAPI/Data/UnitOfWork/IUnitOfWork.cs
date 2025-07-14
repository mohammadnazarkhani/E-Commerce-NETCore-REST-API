using System;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce.RestAPI.Data.UnitOfWork;

/// <summary>
/// Unit of work interface for managing transactions across multiple repositories
/// Provides centralized access to all entity repositories and transaction management
/// </summary>
public interface IUnitOfWork : IDisposable
{
    #region Entity Repositories

    /// <summary>
    /// Repository for User entities
    /// </summary>
    IRepository<User> Users { get; }

    /// <summary>
    /// Repository for Vendor entities
    /// </summary>
    IRepository<Vendor> Vendors { get; }

    /// <summary>
    /// Repository for Product entities
    /// </summary>
    IRepository<Product> Products { get; }

    /// <summary>
    /// Repository for Category entities
    /// </summary>
    IRepository<Category> Categories { get; }

    /// <summary>
    /// Repository for Cart entities
    /// </summary>
    IRepository<Cart> Carts { get; }

    /// <summary>
    /// Repository for CartItem entities
    /// </summary>
    IRepository<CartItem> CartItems { get; }

    /// <summary>
    /// Repository for Order entities
    /// </summary>
    IRepository<Order> Orders { get; }

    /// <summary>
    /// Repository for OrderItem entities
    /// </summary>
    IRepository<OrderItem> OrderItems { get; }

    /// <summary>
    /// Repository for Payment entities
    /// </summary>
    IRepository<Payment> Payments { get; }

    /// <summary>
    /// Repository for Review entities
    /// </summary>
    IRepository<Review> Reviews { get; }

    /// <summary>
    /// Repository for Question entities
    /// </summary>
    IRepository<Question> Questions { get; }

    /// <summary>
    /// Repository for UserAddress entities
    /// </summary>
    IRepository<UserAddress> UserAddresses { get; }

    /// <summary>
    /// Repository for Province entities
    /// </summary>
    IRepository<Province> Provinces { get; }

    /// <summary>
    /// Repository for City entities
    /// </summary>
    IRepository<City> Cities { get; }

    /// <summary>
    /// Repository for ShipmentDepartment entities
    /// </summary>
    IRepository<ShipmentDepartment> ShipmentDepartments { get; }

    #endregion

    #region Generic Repository Access

    /// <summary>
    /// Gets a generic repository for any entity type
    /// </summary>
    /// <typeparam name="TEntity">Entitiy type</typeparam>
    /// <returns>Repository instance for the specified entity type</returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

    #endregion

    #region Transaction Management

    /// <summary>
    /// Begins a database transaction
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Database transaction</returns>
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Rolls back the current transaction
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute a function within a transaction scope
    /// </summary>
    /// <typeparam name="TResult">Return type</typeparam>
    /// <param name="opration">Opration to execute</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result of the opration</returns>
    Task<TResult> ExecuteInTransactionAsync<TResult>(
        Func<Task<TResult>> opration,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes an action w0ithin a transaction scope
    /// </summary>
    /// <param name="opration">Opration to execute</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task ExecuteInTransatctionAsync(
        Func<Task> opration,
        CancellationToken cancellationToken = default
    );

    #endregion

    #region Save Oprations

    /// <summary>
    /// Saves all changes made in this unit of work to the database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of entities written to the database</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves all changes and returns success indicator
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if save wass successful, false otherwise</returns>
    Task<bool> TrySaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion

    #region Bulk Oprations

    /// <summary>
    /// Executes a bulk opration across multiple repositories
    /// </summary>
    /// <param name="oprations">Array of oprations to execute</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the bulk opration</returns>
    Task ExecuteBulkOprationAsync(
        Func<IUnitOfWork, Task>[] oprations,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes raw SQL command against the database
    /// </summary>
    /// <param name="sql">SQL command</param>
    /// <param name="parameters">Command parameters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of affected rows</returns>
    Task<int> ExecuteRawSqlAsync(
        string sql,
        object[] parameters,
        CancellationToken cancellationToken = default
    );

    #endregion

    #region State Management

    /// <summary>
    /// Gets the current state of the unit of work
    /// </summary>
    UnitOfWorkState State { get; }

    /// <summary>
    /// Checks if there are any pending changes
    /// </summary>
    bool HasPendingChanges { get; }

    /// <summary>
    /// Discards all pending changes
    /// </summary>
    void DiscardChanges();

    /// <summary>
    /// Resets unit of work to its intial state
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    Task ResetAsync(CancellationToken cancellationToken = default);

    #endregion

    #region Events

    /// <summary>
    /// Envet raised before saving changes
    /// </summary>
    event Func<CancellationToken, Task> BeforeSaveChanges;

    /// <summary>
    /// Event raised after saving changes
    /// </summary>
    event Func<int, CancellationToken, Task> AfterSaveChanges;

    /// <summary>
    /// Event raised when save changes fails
    /// </summary>
    event Func<Exception, CancellationToken, Task> SaveChangesFailded;

    #endregion

    #region Advanced Features

    /// <summary>
    /// Creates a save3point within the current transaction
    /// </summary>
    /// <param name="name">Savepoint name</param>
    /// <param name="cancellationToken">Cancellation tokne</param>
    /// <returns>Task representing the opration</returns>
    Task CreateSavepointAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rolls back to a specific savepoint
    /// </summary>
    /// <param name="name">Savepont name</param>
    /// <param name="cancellatioinToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task RollbackToSavepointAsync(string name, CancellationToken cancellatioinToken = default);

    /// <summary>
    /// Release a savepoint
    /// </summary>
    /// <param name="name">Savepoint name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    Task ReleaseSavepointAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables or disables auto-detect changes
    /// </summary>
    /// <param name="enabled">Wether to enable auto-detect changes</param>
    void SetAutoDetectChanges(bool enabled);

    /// <summary>
    /// Munually detects changes in tracked entities
    /// </summary>
    void DetectChanges();

    #endregion
}
