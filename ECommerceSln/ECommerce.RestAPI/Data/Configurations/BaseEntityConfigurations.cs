using ECommerce.RestAPI.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.RestAPI.Data.Configurations
{
    public class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntityBase>
    {
        public void Configure(EntityTypeBuilder<AuditableEntityBase> builder)
        {
            // Use Table Per Concrete Type strategy
            builder.UseTpcMappingStrategy();

            // Configure Id property
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .IsRequired();

            // Configure audit fields
            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.LastModifiedAt)
                .IsConcurrencyToken() // Optimistic concurrency control
                .ValueGeneratedOnUpdate();

            // Create indexes for better query performance
            builder.HasIndex(e => e.CreatedAt);
            builder.HasIndex(e => e.LastModifiedAt);
        }
    }
}
