using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.RestAPI.Data
{
    public class ECommerceDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        // DbSets for all entities
        public new DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ShipmentDepartment> ShipmentDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply all configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);
        }
    }
}
