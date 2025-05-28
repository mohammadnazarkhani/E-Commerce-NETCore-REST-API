using System;
using MockSmsProvider.Models;

namespace MockSmsProvider.Services.Interfaces;

/// <summary>
/// Provides methods to manage and retrieve user inbox messages and inbox information.
/// This service interface defines the contract for handling SMS inbox operations.
/// </summary>
public interface IInboxService
{
    /// <summary>
    /// Retrieves a list of SMS messages for a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose messages to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of SMS messages.</returns>
    /// <exception cref="ArgumentNullException">Thrown when userId is null or empty.</exception>
    Task<List<Sms>> GetUserInboxMessagesByUserId(string userId);

    /// <summary>
    /// Retrieves the complete inbox information for a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose inbox to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user's inbox information.</returns>
    /// <exception cref="ArgumentNullException">Thrown when userId is null or empty.</exception>
    Task<Inbox> GetUserInbox(string userId);
}
