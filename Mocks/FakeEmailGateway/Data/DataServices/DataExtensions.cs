using System;
using Microsoft.EntityFrameworkCore;

namespace FakeEmailGateway.Data;

public static class DataExtensions
{
    /// <summary>
    /// Asynchronously checks if the database is empty by querying the Users table.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task<bool> IsDatabaseEmptyAsync(this ApplicationDbContext context)
    {
        return !await context.Users.AnyAsync();
    }

    /// <summary>
    /// Asynchronously migrates the database if there are any pending migrations.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static async Task MigrateIfAnyPendingMigrationsAsync(this ApplicationDbContext context)
    {
        if (context.Database.IsRelational())
        {
            // Check if there are any pending migrations
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                // Apply the pending migrations
                await context.Database.MigrateAsync();
            }
        }
        else
        {
            throw new NotSupportedException("Database type not supported for migration.");
        }
    }

    /// <summary>
    /// Asynchronously ensures that the database is created.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static async Task entsureDatabaseIsCreatedAsync(this ApplicationDbContext context)
    {
        if (context.Database.IsRelational())
        {
            // Ensure the database is created
            await context.Database.EnsureCreatedAsync();
        }
        else
        {
            throw new NotSupportedException("Database type not supported for creation.");
        }
    }
}