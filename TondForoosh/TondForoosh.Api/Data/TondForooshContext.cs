using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Data
{
    public class TondForooshContext : DbContext
    {
        public TondForooshContext(DbContextOptions<TondForooshContext> options) : base(options)
        {
        }

        // DbSets for each model
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify decimal precision and scale to avoid truncation warnings
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            // User to ShoppingCart: One-to-One
            modelBuilder.Entity<User>()
                .HasOne(u => u.ShoppingCart)
                .WithOne(sc => sc.User)
                .HasForeignKey<ShoppingCart>(sc => sc.UserId);

            // User to Orders: One-to-Many
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // ProductCategory to Products: One-to-Many
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);

            // ShoppingCart to CartItems: One-to-Many
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.CartItems)
                .WithOne(ci => ci.ShoppingCart)
                .HasForeignKey(ci => ci.ShoppingCartId);

            // Product to CartItems: One-to-Many
            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId);

            // Order to OrderItems: One-to-Many
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Product to OrderItems: One-to-Many
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);

            // Defining relationships for SellerProduct
            modelBuilder.Entity<SellerProduct>()
                .HasKey(sp => sp.Id);

            // SellerProduct to User (Seller): Many-to-One
            modelBuilder.Entity<SellerProduct>()
                .HasOne(sp => sp.Seller)
                .WithMany(u => u.SellerProducts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust DeleteBehavior as needed

            // SellerProduct to Product: Many-to-One
            modelBuilder.Entity<SellerProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SellerProducts)
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust DeleteBehavior as needed
        }
    }
}
