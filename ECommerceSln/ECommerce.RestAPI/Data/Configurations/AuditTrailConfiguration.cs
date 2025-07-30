using System;
using ECommerce.RestAPI.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.RestAPI.Data.Configurations;

public class AuditTrailConfiguration : IEntityTypeConfiguration<AuditTrail>
{
    public void Configure(EntityTypeBuilder<AuditTrail> builder)
    {
        builder.Property(a => a.Action)
            .HasConversion<string>() // Store enum as string
            .HasMaxLength(50);

        builder.Property(a => a.Source)
            .HasConversion<string>() // Store enum as string
            .HasMaxLength(100);
    }
}
