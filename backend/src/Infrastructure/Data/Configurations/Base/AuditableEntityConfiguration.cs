using System;
using Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Base;

public class AuditableEntityConfiguration<TId> : IEntityTypeConfiguration<AuditableEntity<TId>>
{
    public void Configure(EntityTypeBuilder<AuditableEntity<TId>> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false);
    }
}
