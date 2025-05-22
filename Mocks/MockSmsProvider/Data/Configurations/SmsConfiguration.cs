using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockSmsProvider.Models;

namespace MockSmsProvider.Data.Configurations;

public class SmsConfiguration : IEntityTypeConfiguration<Sms>
{
    public void Configure(EntityTypeBuilder<Sms> builder)
    {
        // Relations
        builder.HasOne(s => s.Inbox)
            .WithMany(i => i.Messages)
            .HasForeignKey(s => s.InboxId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.Sender)
            .WithMany(sender => sender.SentMessages)
            .HasForeignKey(s => s.SenderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
