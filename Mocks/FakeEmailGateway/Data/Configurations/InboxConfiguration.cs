using System;
using FakeEmailGateway.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeEmailGateway.Data.Configurations;

public class InboxConfiguration : IEntityTypeConfiguration<Inbox>
{
    public void Configure(EntityTypeBuilder<Inbox> builder)
    {
        // Relations
        builder.HasOne(i => i.User)
            .WithOne(u => u.Inbox)
            .HasForeignKey<Inbox>(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(i => i.UserId).IsUnique();
    }
}
