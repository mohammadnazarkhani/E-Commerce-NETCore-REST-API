using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Entities.Base;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Core.Common.Exceptions;

namespace Infrastructure.Data;

public class TFDbContext : DbContext
{
    private readonly ILogger<TFDbContext> _logger;

    public TFDbContext(
        DbContextOptions<TFDbContext> options,
        ILogger<TFDbContext> logger) : base(options)
    {
        _logger = logger;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            // Get all entries that inherit from AuditableEntity<> and have changes
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().IsGenericType &&
                           e.Entity.GetType().GetGenericTypeDefinition() == typeof(AuditableEntity<>) &&
                           e.State != EntityState.Unchanged)
                .ToList();

            // Call OnSaving for each changed entity
            foreach (var entry in entries)
            {
                ((dynamic)entry.Entity).OnSaving();
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            // Call OnSaved for each changed entity
            foreach (var entry in entries)
            {
                ((dynamic)entry.Entity).OnSaved();
            }

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "Concurrency conflict detected");
            throw new DomainException("The record was modified by another user");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TFDbContext).Assembly);
    }
}
