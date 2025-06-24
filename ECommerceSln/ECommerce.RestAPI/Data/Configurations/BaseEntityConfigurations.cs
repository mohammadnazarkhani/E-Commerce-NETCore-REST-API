using ECommerce.RestAPI.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.RestAPI.Data.Configurations
{
    public class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntityBase>
    {
        public void Configure(EntityTypeBuilder<AuditableEntityBase> builder)
        {
            builder.UseTpcMappingStrategy();

            builder.Property(e => e.CreatedAt)
                .HasDefaultValue("GETUTCDATE()");
        }
    }
}
