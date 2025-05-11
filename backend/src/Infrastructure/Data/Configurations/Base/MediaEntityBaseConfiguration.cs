using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Base;

namespace Infrastructure.Data.Configurations.Base;

public class MediaEntityBaseConfiguration : IEntityTypeConfiguration<BaseMediaEntity>
{
    public void Configure(EntityTypeBuilder<BaseMediaEntity> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
                .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.UpdatedAt)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.HasIndex(e => e.CreatedAt);
    }
}
