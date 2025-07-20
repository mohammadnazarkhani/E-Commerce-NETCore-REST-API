using System;
using ECommerce.RestAPI.Data.Extensions;
using ECommerce.RestAPI.Data.UnitOfWork;

namespace ECommerce.RestAPI.Data.Repository;


/// <summary>
/// Builder for configuring repository pattern services
/// </summary>
public class RepositoryPatternBuilder
{
    private readonly IServiceCollection _services;
    private readonly RepositoryPatternOptions _options;

    public RepositoryPatternBuilder(IServiceCollection services)
    {
        _services = services;
        _options = new RepositoryPatternOptions();
    }

    /// <summary>
    /// Configures repository lifetime
    /// </summary>
    /// <param name="lifetime">Service lifetime</param>
    /// <returns>Builder instance for chaining</returns>
    public RepositoryPatternBuilder WithRepositoryLifetime(ServiceLifetime lifetime)
    {
        _options.RepositoryLifetime = lifetime;
        return this;
    }

    /// <summary>
    /// Configures Unit of Work lifetime
    /// </summary>
    /// <param name="lifetime">Service lifetime</param>
    /// <returns>Builder instance for chaining</returns>
    public RepositoryPatternBuilder WithUnitOfWorkLifetime(ServiceLifetime lifetime)
    {
        _options.UnitOfWorkLifetime = lifetime;
        return this;
    }

    /// <summary>
    /// Configures Repository Factory lifetime
    /// </summary>
    /// <param name="lifetime">Service lifetime</param>
    /// <returns>Builder instance for chaining</returns>
    public RepositoryPatternBuilder WithFactoryLifetime(ServiceLifetime lifetime)
    {
        _options.FactoryLifetime = lifetime;
        return this;
    }

    /// <summary>
    /// Enables repository caching
    /// </summary>
    /// <returns>Builder instance for chaining</returns>
    public RepositoryPatternBuilder EnableRepositoryCaching()
    {
        _options.EnableRepositoryCaching = true;
        return this;
    }

    /// <summary>
    /// Disables service validation on startup
    /// </summary>
    /// <returns>Builder instance for chaining</returns>
    public RepositoryPatternBuilder DisableValidation()
    {
        _options.ValidateOnStartup = false;
        return this;
    }

    /// <summary>
    /// Builds and applies the configuration
    /// </summary>
    /// <returns>Service collection for chaining</returns>
    public IServiceCollection Build<TRepository, TUnitOfWork>()
        where TRepository : class
        where TUnitOfWork : class, IUnitOfWork
    {
        return _services.AddRepositoryPattern<TRepository, TUnitOfWork>(options =>
        {
            options.RepositoryLifetime = _options.RepositoryLifetime;
            options.UnitOfWorkLifetime = _options.UnitOfWorkLifetime;
            options.FactoryLifetime = _options.FactoryLifetime;
            options.EnableRepositoryCaching = _options.EnableRepositoryCaching;
            options.ValidateOnStartup = _options.ValidateOnStartup;
        });
    }
}
