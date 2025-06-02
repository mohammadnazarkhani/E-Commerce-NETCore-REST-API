using System;
using Microsoft.EntityFrameworkCore;

namespace FakeEmailGateway.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : DbContext(opts)
{
    public DbSet<Models.User> Users { get; set; } = null!;
    public DbSet<Models.Outbox> Outboxes { get; set; } = null!;
    public DbSet<Models.Inbox> Inboxes { get; set; } = null!;
    public DbSet<Models.Email> Emails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
