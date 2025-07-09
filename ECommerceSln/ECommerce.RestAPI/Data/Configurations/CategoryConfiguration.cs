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
                new Category { Id = Guid.NewGuid(), Name = "Electronics" },
                new Category { Id = Guid.NewGuid(), Name = "Books" },
                new Category { Id = Guid.NewGuid(), Name = "Clothing" },
                new Category { Id = Guid.NewGuid(), Name = "Home & Kitchen" },
                new Category { Id = Guid.NewGuid(), Name = "Sports & Outdoors" }
            );
        }
    }
}
