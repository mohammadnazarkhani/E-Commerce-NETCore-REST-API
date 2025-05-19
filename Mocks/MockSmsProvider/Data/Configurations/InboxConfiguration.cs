using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockSmsProvider.Models;

namespace MockSmsProvider.Data.Configurations;

public class InboxConfiguration : IEntityTypeConfiguration<Inbox>
{
    public void Configure(EntityTypeBuilder<Inbox> builder)
    {
        // Relations
        builder.HasOne(i => i.User)
            .WithOne(u => u.Inbox)
            .HasForeignKey<Inbox>(i => i.UserId);
    }
}
