using System;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Factory;

/// <summary>
/// Repository factory interface for creating repositories dynamically.
/// Privides centralized repository creation with caching and depenency injection support.
/// </summary>
public interface IRepositoryFactory
{
    /// <summary>
    /// Creates or retrieves a cached repository for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">Entity type that implements IEntity</typeparam>
    /// <returns>Repository instance for the specified entity type</returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

    /// <summary>
    /// Creates or retrieves a cached repository for the specified entity type.
    /// This method is useful when the entity type is not known at compile time.
    /// </summary>
    /// <param name="entityType">Type of the entity</param>
    /// <returns>Repository instance for the specified entity type</returns>
    object GetRepository(Type entityType);

    /// <summary>
    /// Clears all cached repositories.
    /// </summary>
    void ClearCache();

    /// <summary>
    /// Gets the count of cached repositories.
    /// This can be useful for monitoring or debugging purposes.
    /// </summary>
    int CachedRepositoriesCount { get; }

    /// <summary>
    /// Checks if a repository for the specified entity type is cached.
    /// This can help avoid unnecessary repository creation and improve performance.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Ture if cached, false otherwise</returns>
    bool IsRepositoryCached<TEntity>() where TEntity : class, IEntity;

    /// <summary>
    /// Removes a specific repository from the cache.
    /// This can be useful when you want to refresh or recreate a repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>True if removed, false if not found</returns>
    bool RemoveFromcache<TEntity>() where TEntity : class, IEntity;
}
