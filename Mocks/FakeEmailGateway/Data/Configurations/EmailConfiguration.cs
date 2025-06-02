using System;
using FakeEmailGateway.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeEmailGateway.Data.Configurations;

public class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        // Relations
        builder.HasOne(e => e.ReceiverInbox)
            .WithMany(i => i.ReceivedEmails)
            .HasForeignKey(e => e.ReceiverInboxId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.SenderOutbox)
            .WithMany(o => o.SentEmails)
            .HasForeignKey(e => e.SenderOutboxId)
            .OnDelete(DeleteBehavior.NoAction);


        // Indexes
        builder.HasIndex(e => e.ReceiverInboxId);
        builder.HasIndex(e => e.SenderOutboxId);
        builder.HasIndex(e => e.Subject).HasDatabaseName("IX_Email_Subject");
    }
}
