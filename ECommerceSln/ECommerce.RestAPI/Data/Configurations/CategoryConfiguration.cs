using ECommerce.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.RestAPI.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.Name)
                   .IsUnique();

            builder.HasData(
                new Category { Name = "Electronics" },
                new Category { Name = "Books" },
                new Category { Name = "Clothing" },
                new Category { Name = "Home & Kitchen" },
                new Category { Name = "Sports & Outdoors" }
            );
        }
    }
}
