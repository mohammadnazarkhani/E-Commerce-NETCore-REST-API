using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Entities.Base;
using System.Runtime.InteropServices;

namespace Infrastructure.Data;

public class TFDbContext : DbContext
{
    public TFDbContext(DbContextOptions<TFDbContext> options) : base(options)
    {

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
