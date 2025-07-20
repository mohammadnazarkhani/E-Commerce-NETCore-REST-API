using System;

namespace ECommerce.RestAPI.Data.Repository;

/// <summary>
/// Configuration options for repository pattern setup
/// </summary>
public class RepositoryPatternOptions
{
    /// <summary>
    /// Service lifetime for repositories (default: Scoped)
    /// </summary>
    public ServiceLifetime RepositoryLifetime { get; set; } = ServiceLifetime.Scoped;

    /// <summary>
    /// Service lifetime for Unit of Work (default: Scoped)
    /// </summary>
    public ServiceLifetime UnitOfWorkLifetime { get; set; } = ServiceLifetime.Scoped;

    /// <summary>
    /// Service lifetime for Repository Factory (default: Scoped)
    /// </summary>
    public ServiceLifetime FactoryLifetime { get; set; } = ServiceLifetime.Scoped;

    /// <summary>
    /// Whether to enable repository caching (default: false)
    /// Only applicable when FactoryLifetime is Singleton
    /// </summary>
    public bool EnableRepositoryCaching { get; set; } = false;

    /// <summary>
    /// Whether to validate services on startup (default: true)
    /// </summary>
    public bool ValidateOnStartup { get; set; } = true;
}