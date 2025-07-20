using System;
using System.Collections.Concurrent;
using ECommerce.RestAPI.Common.Exceptions;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Factory;

/// <summary>
/// Default implementation of IRepositoryFactory.
/// Privides caching, lazy loading, and thread-safe repository creation.
/// </summary>
public class RepositoryFactory : IRepositoryFactory, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ConcurrentDictionary<Type, object> _repositoryCache;
    private readonly object _lock = new object();
    private bool _disposed = false;

    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _repositoryCache = new ConcurrentDictionary<Type, object>();
    }

    /// <inheritdoc />
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
    {
        ValidateEntityType<TEntity>();

        return (IRepository<TEntity>)_repositoryCache.GetOrAdd(
            typeof(TEntity),
            entityType => CreateRepository<TEntity>()
        );
    }

    /// <inheritdoc />
    public object GetRepository(Type entityType)
    {
        ValidateEntityType(entityType);

        return _repositoryCache.GetOrAdd(
            entityType,
            type => CreateRepository(type)
        );
    }

    /// <inheritdoc />
    public void ClearCache()
    {
        lock (_lock)
        {
            // Dispose repositories if they implement IDisposable
            foreach (var repository in _repositoryCache.Values)
            {
                if (repository is IDisposable disposableRepository)
                {
                    disposableRepository.Dispose();
                }
            }

            _repositoryCache.Clear();
        }
    }

    /// <inheritdoc />
    public int CachedRepositoriesCount => _repositoryCache.Count;

    /// <inheritdoc />
    public bool IsRepositoryCached<TEntity>() where TEntity : class, IEntity
    {
        return _repositoryCache.ContainsKey(typeof(TEntity));
    }

    /// <inheritdoc />
    public bool RemoveFromCache<TEntity>() where TEntity : class, IEntity
    {
        var removed = _repositoryCache.TryRemove(typeof(TEntity), out var repository);

        if (removed && repository is IDisposable disposableRepository)
        {
            disposableRepository.Dispose();
        }

        return removed;
    }

    /// <summary>
    /// Creates a repository instance for the specified entity type.
    /// Uses the service provider to resolve the repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Repository instance</returns>
    /// <exception cref="RepositoryFactoryException">Thrown if repository creation fails</exception>
    private object CreateRepository<TEntity>() where TEntity : class, IEntity
    {
        try
        {
            var repository = _serviceProvider.GetService<IRepository<TEntity>>();

            if (repository == null)
            {
                throw new InvalidOperationException($"Repository for type {typeof(TEntity).Name} could not be created. Ensure it is registered in the service provider.");
            }

            return repository;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryFactoryException($"Failed to create repository for type {typeof(TEntity).Name}.", ex);
        }
    }

    /// <summary>
    /// Creates a repository instance for the specified entity type.
    /// Uses the service provider to resolve the repository.
    /// </summary>
    /// <param name="type">Entity type</param>
    /// <returns>Repository instance</returns>
    private object CreateRepository(Type entityType)
    {
        try
        {
            var repository = _serviceProvider.GetService(typeof(IRepository<>).MakeGenericType(entityType));

            if (repository == null)
            {
                throw new InvalidOperationException(
                    $"Repository for type {entityType.Name} could not be created. Ensure it is registered in the service provider."
                );
            }

            return repository;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryFactoryException($"Failed to create repository for type {entityType.Name}.", ex);
        }
    }

    /// <summary>
    /// Vlidates that the entity type implements IEntity interface and is a class.
    /// This is to ensure that the repository can only be created for valid entity types.
    /// </summary>
    /// <typeparam name="TEntity">Entity type to validate</typeparam>
    /// <exception cref="ArgumentException">Thrown if TEntity is not a class or does not implement IEntity</exception>
    private void ValidateEntityType<TEntity>() where TEntity : class, IEntity
    {
        // Generic constraint already ensures this, but keeping for explicit validation
        if (!typeof(TEntity).IsClass || !typeof(IEntity).IsAssignableFrom(typeof(TEntity)))
        {
            throw new ArgumentException($"Type {typeof(TEntity).Name} must be a class and implement IEntity interface.", nameof(TEntity));
        }
    }

    /// <summary>
    /// Validates that the entity type implements IEntity interface
    /// </summary>
    /// <param name="entityType">Entity type to validate</param>
    private void ValidateEntityType(Type entityType)
    {
        if (entityType == null)
            throw new ArgumentNullException(nameof(entityType));

        if (!typeof(IEntity).IsAssignableFrom(entityType))
        {
            throw new ArgumentException(
                $"Entity type '{entityType.Name}' must implement IEntity interface",
                nameof(entityType)
            );
        }

        if (!entityType.IsClass)
        {
            throw new ArgumentException(
                $"Entity type '{entityType.Name}' must be a class",
                nameof(entityType)
            );
        }
    }

    /// <summary>
    /// Disposes the factory and clears all cached repositories
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Protected dispose method
    /// </summary>
    /// <param name="disposing">Indicates if disposing</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            ClearCache();
            _disposed = true;
        }
    }
}
