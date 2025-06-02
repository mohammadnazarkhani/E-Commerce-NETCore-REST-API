using System;
using Microsoft.EntityFrameworkCore;

namespace FakeEmailGateway.Data.DataServices;

public class DbInitializerService : IHostedService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public DbInitializerService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

        // Ensure the database is created
        await context.entsureDatabaseIsCreatedAsync();

        // Migrate if there are any pending migrations
        await context.MigrateIfAnyPendingMigrationsAsync();

        // Optionally, you can seed initial data here if needed
        if (await context.IsDatabaseEmptyAsync())
        {
            // Seed initial data if necessary
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // No specific actions needed on stop
        return Task.CompletedTask;
    }
}
