using System;
using MockSmsProvider.Data;

namespace MockSmsProvider.Services.Base;

/// <summary>
/// Provides a base implementation for services that require database access through Entity Framework Core.
/// This class serves as the foundation for all service classes in the application that need database operations.
/// </summary>
public class ServiceBase
{
    /// <summary>
    /// The Entity Framework database context instance used for database operations.
    /// Protected access allows derived classes to use this context for their specific data access needs.
    /// </summary>
    protected ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceBase"/> class.
    /// </summary>
    /// <param name="context">The database context to be used for data access operations.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
    public ServiceBase(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
