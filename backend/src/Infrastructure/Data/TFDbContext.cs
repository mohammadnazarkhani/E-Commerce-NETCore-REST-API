using Microsoft.EntityFrameworkCore;
using Core.Entities;

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

        modelBuilder.Entity<Product>()
           .HasOne(p => p.MainImage)
           .WithOne(i => i.Product)
           .HasForeignKey<ProductImage>(i => i.ProductId);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
    }
}
