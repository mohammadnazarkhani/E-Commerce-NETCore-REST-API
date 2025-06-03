using System;
using FakeEmailGateway.Data.Repository;
using FakeEmailGateway.Models;

namespace FakeEmailGateway.Data.UnitOfWork;

/// <summary>
/// Represents a unit of work that encapsulates a set of operations to be performed as a single transaction.
/// The unit of work pattern is used to group multiple operations into a single transaction, ensuring that either all operations succeed or none do.
/// </summary>
public interface IUnitOfWork
{
    Repository<User> UsersRepo { get; set; }
    Repository<Email> EmailsRepo { get; set; }
    Repository<Inbox> InboxesRepo { get; set; }
    Repository<Outbox> OutboxesRepo { get; set; }

    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveChangesAsync();

    /// <summary>
    /// Disposes of the unit of work, releasing any resources it holds.
    /// </summary>
    void Dispose();
}
