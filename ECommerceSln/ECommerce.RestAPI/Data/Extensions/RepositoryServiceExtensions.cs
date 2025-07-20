using ECommerce.RestAPI.Data.Factory;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Data.UnitOfWork;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Extensions;

/// <summary>
/// Extension methods for configuring repository services in dependency injection container
/// </summary>
public static class RepositoryServiceExtensions
{
    /// <summary>
    /// Adds repository factory services to the service collection
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="factoryLifetime">Lifetime for the repository factory (default: Scoped)</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddRepositoryFactory(
        this IServiceCollection services,
        ServiceLifetime factoryLifetime = ServiceLifetime.Scoped)
    {
        // Add the repository factory based on lifetime
        switch (factoryLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<IRepositoryFactory, ScopedRepositoryFactory>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<IRepositoryFactory, ScopedRepositoryFactory>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(factoryLifetime));
        }

        return services;
    }

    /// <summary>
    /// Adds cached repository factory (singleton) to the service collection
    /// Use this for scenarios where repository caching across the application lifetime is desired
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddCachedRepositoryFactory(this IServiceCollection services)
    {
        services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        return services;
    }

    /// <summary>
    /// Adds scoped repository factory to the service collection
    /// Use this for web applications where repositories should be scoped per request
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddScopedRepositoryFactory(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryFactory, ScopedRepositoryFactory>();
        return services;
    }

    /// <summary>
    /// Adds all ECommerce entity repositories to the service collection
    /// This method registers all the repositories mentioned in your UnitOfWork interface
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="repositoryLifetime">Lifetime for repositories (default: Scoped)</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddECommerceRepositories<TRepository>(
        this IServiceCollection services,
        ServiceLifetime repositoryLifetime = ServiceLifetime.Scoped)
        where TRepository : class
    {
        // Register all entity repositories
        RegisterRepository<User, TRepository>(services, repositoryLifetime);
        RegisterRepository<Vendor, TRepository>(services, repositoryLifetime);
        RegisterRepository<Product, TRepository>(services, repositoryLifetime);
        RegisterRepository<Category, TRepository>(services, repositoryLifetime);
        RegisterRepository<Cart, TRepository>(services, repositoryLifetime);
        RegisterRepository<CartItem, TRepository>(services, repositoryLifetime);
        RegisterRepository<Order, TRepository>(services, repositoryLifetime);
        RegisterRepository<OrderItem, TRepository>(services, repositoryLifetime);
        RegisterRepository<Payment, TRepository>(services, repositoryLifetime);
        RegisterRepository<Review, TRepository>(services, repositoryLifetime);
        RegisterRepository<Question, TRepository>(services, repositoryLifetime);
        RegisterRepository<UserAddress, TRepository>(services, repositoryLifetime);
        RegisterRepository<Province, TRepository>(services, repositoryLifetime);
        RegisterRepository<City, TRepository>(services, repositoryLifetime);
        RegisterRepository<ShipmentDepartment, TRepository>(services, repositoryLifetime);

        return services;
    }

    /// <summary>
    /// Adds complete repository pattern services including Unit of Work and Repository Factory
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configureOptions">Configuration options</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddRepositoryPattern<TRepository, TUnitOfWork>(
        this IServiceCollection services,
        Action<RepositoryPatternOptions>? configureOptions = null)
        where TRepository : class
        where TUnitOfWork : class, IUnitOfWork
    {
        var options = new RepositoryPatternOptions();
        configureOptions?.Invoke(options);

        // Add repositories
        services.AddECommerceRepositories<TRepository>(options.RepositoryLifetime);

        // Add Unit of Work
        switch (options.UnitOfWorkLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<IUnitOfWork, TUnitOfWork>();
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<IUnitOfWork, TUnitOfWork>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<IUnitOfWork, TUnitOfWork>();
                break;
        }

        // Add Repository Factory
        services.AddRepositoryFactory(options.FactoryLifetime);

        return services;
    }

    /// <summary>
    /// Registers a repository for a specific entity type
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TRepository">Repository implementation type</typeparam>
    /// <param name="services">Service collection</param>
    /// <param name="lifetime">Service lifetime</param>
    private static void RegisterRepository<TEntity, TRepository>(
        IServiceCollection services,
        ServiceLifetime lifetime)
        where TEntity : class, IEntity
        where TRepository : class
    {
        var serviceDescriptor = new ServiceDescriptor(
            typeof(IRepository<TEntity>),
            typeof(TRepository),
            lifetime
        );

        services.Add(serviceDescriptor);
    }

    /// <summary>
    /// Adds repository factory with custom factory implementation
    /// </summary>
    /// <typeparam name="TFactory">Custom factory implementation</typeparam>
    /// <param name="services">Service collection</param>
    /// <param name="factoryLifetime">Factory lifetime</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddCustomRepositoryFactory<TFactory>(
        this IServiceCollection services,
        ServiceLifetime factoryLifetime = ServiceLifetime.Scoped)
        where TFactory : class, IRepositoryFactory
    {
        switch (factoryLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<IRepositoryFactory, TFactory>();
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<IRepositoryFactory, TFactory>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<IRepositoryFactory, TFactory>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(factoryLifetime));
        }

        return services;
    }

    /// <summary>
    /// Validates that all required repository services are registered
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection ValidateRepositoryServices(this IServiceCollection services)
    {
        // This method can be extended to perform validation logic
        // For now, it's a placeholder for future validation needs
        return services;
    }
}