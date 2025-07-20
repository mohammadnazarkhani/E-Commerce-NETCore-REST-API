using System;
using ECommerce.RestAPI.Data.Repository;

namespace ECommerce.RestAPI.Data.Extensions;

/// <summary>
/// Extension method to create repository pattern builder
/// </summary>
public static class RepositoryPatternBuilderExtensions
{
    /// <summary>
    /// Creates a new repository pattern builder
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>Repository pattern builder</returns>
    public static RepositoryPatternBuilder AddRepositoryPatternBuilder(this IServiceCollection services)
    {
        return new RepositoryPatternBuilder(services);
    }
}