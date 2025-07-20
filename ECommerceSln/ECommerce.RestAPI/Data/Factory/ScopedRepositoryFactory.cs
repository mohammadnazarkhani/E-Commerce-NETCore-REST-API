using System;
using ECommerce.RestAPI.Common.Exceptions;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Factory;

/// <summary>
/// Scoped repository factory that ensures repositories are scoped per request/operation
/// Ideal for web applications where repositories should not be cached across requests
/// </summary>
public class ScopedRepositoryFactory : IRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ScopedRepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    /// <inheritdoc />
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
    {
        ValidateEntityType<TEntity>();
        
        try
        {
            var repository = _serviceProvider.GetService<IRepository<TEntity>>();
            
            if (repository == null)
            {
                throw new InvalidOperationException(
                    $"Repository for entity type '{typeof(TEntity).Name}' is not registered in the service container."
                );
            }
            
            return repository;
        }
        catch (Exception ex)
        {
            throw new RepositoryFactoryException(
                $"Failed to create repository for entity type '{typeof(TEntity).Name}'", 
                ex
            );
        }
    }

    /// <inheritdoc />
    public object GetRepository(Type entityType)
    {
        ValidateEntityType(entityType);

        try
        {
            var repositoryType = typeof(IRepository<>).MakeGenericType(entityType);
            var repository = _serviceProvider.GetService(repositoryType);
            
            if (repository == null)
            {
                throw new InvalidOperationException(
                    $"Repository for entity type '{entityType.Name}' is not registered in the service container."
                );
            }
            
            return repository;
        }
        catch (Exception ex)
        {
            throw new RepositoryFactoryException(
                $"Failed to create repository for entity type '{entityType.Name}'", 
                ex
            );
        }
    }

    /// <inheritdoc />
    public void ClearCache()
    {
        // No caching in scoped factory
    }

    /// <inheritdoc />
    public int CachedRepositoriesCount => 0; // No caching in scoped factory

    /// <inheritdoc />
    public bool IsRepositoryCached<TEntity>() where TEntity : class, IEntity
    {
        return false; // No caching in scoped factory
    }

    /// <inheritdoc />
    public bool RemoveFromCache<TEntity>() where TEntity : class, IEntity
    {
        return false; // No caching in scoped factory
    }

    private static void ValidateEntityType<TEntity>() where TEntity : class, IEntity
    {
        if (!typeof(IEntity).IsAssignableFrom(typeof(TEntity)))
        {
            throw new ArgumentException(
                $"Entity type '{typeof(TEntity).Name}' must implement IEntity interface",
                nameof(TEntity)
            );
        }
    }

    private static void ValidateEntityType(Type entityType)
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
}