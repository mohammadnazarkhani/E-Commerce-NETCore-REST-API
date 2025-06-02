using System;
using FakeEmailGateway.Data.Repository;
using FakeEmailGateway.Models;

namespace FakeEmailGateway.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public Repository<User> UsersRepo { get; set; }
    public Repository<Email> EmailsRepo { get; set; }
    public Repository<Inbox> InboxesRepo { get; set; }
    public Repository<Outbox> OutboxesRepo { get; set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context), "ApplicationDbContext cannot be null");

        UsersRepo = new Repository<User>(context);
        EmailsRepo = new Repository<Email>(context);
        InboxesRepo = new Repository<Inbox>(context);
        OutboxesRepo = new Repository<Outbox>(context);
    }

    public void Dispose()
    {
        // Dispose of any resources if necessary
        // This is a placeholder implementation
    }

    public Task SaveChangesAsync()
    {
        if (context == null)
            throw new InvalidOperationException("ApplicationDbContext is not initialized.");

        return context.SaveChangesAsync();
    }
}
