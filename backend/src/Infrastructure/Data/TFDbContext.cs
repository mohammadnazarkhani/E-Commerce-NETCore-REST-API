using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Entities.Base;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TFDbContext).Assembly);
    }
}
