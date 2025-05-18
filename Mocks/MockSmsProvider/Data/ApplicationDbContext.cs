using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using MockSmsProvider.Models;

namespace MockSmsProvider.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
        : base(opts)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Inbox> Inboxes { get; set; }
    public DbSet<Sms> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
