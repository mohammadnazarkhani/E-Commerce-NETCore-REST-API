using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Base;
using System.Net.Mime;

namespace Infrastructure.Data.Configurations.Base;

public class MediaEntityBaseConfiguration : IEntityTypeConfiguration<BaseMediaEntity>
{
    public void Configure(EntityTypeBuilder<BaseMediaEntity> builder)
    {
        builder.UseTpcMappingStrategy();

        // Audit fields
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
                .HasMaxLength(100)
                .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasMaxLength(100)
            .IsRequired();

        // Media-specific fields
        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.FileSize)
            .IsRequired();

        // Indexes
        builder.HasIndex(e => e.CreatedAt);
        builder.HasIndex(e => e.Name);
    }
}
