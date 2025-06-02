using System;
using FakeEmailGateway.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeEmailGateway.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Relations
        builder.HasOne(u => u.Outbox)
            .WithOne(o => o.User)
            .HasForeignKey<Outbox>(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.Inbox)
            .WithOne(i => i.User)
            .HasForeignKey<Inbox>(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(u => u.EmailAddress).IsUnique();
    }
}
