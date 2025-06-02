using System;
using FakeEmailGateway.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeEmailGateway.Data.Configurations;

public class OutboxConfiguration : IEntityTypeConfiguration<Outbox>
{
    public void Configure(EntityTypeBuilder<Outbox> builder)
    {
        // Relations
        builder.HasOne(o => o.User)
            .WithOne(u => u.Outbox)
            .HasForeignKey<Outbox>(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(o => o.UserId).IsUnique();
    }
}
