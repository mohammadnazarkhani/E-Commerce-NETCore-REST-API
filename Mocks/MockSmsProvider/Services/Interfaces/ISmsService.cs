using System;

namespace MockSmsProvider.Services.Interfaces;

/// <summary>
/// Provides methods to manage SMS messages between users in the system.
/// This service handles the core SMS functionality including message sending and delivery.
/// </summary>
/// <remarks>
/// This interface is designed to be implemented by concrete SMS service providers.
/// It abstracts the SMS handling logic to allow for different implementations
/// such as mock providers for testing or real SMS gateway integrations.
/// </remarks>
public interface ISmsService
{
    /// <summary>
    /// Sends an SMS message from one user to another.
    /// </summary>
    /// <param name="senderId">The unique identifier of the user sending the message</param>
    /// <param name="userId">The unique identifier of the user receiving the message</param>
    /// <param name="message">The content of the SMS message to be sent</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains:
    /// - true: if the message was sent successfully
    /// - false: if the message failed to send
    /// </returns>
    /// <remarks>
    /// The method validates both sender and recipient existence before attempting to send the message.
    /// Message delivery is asynchronous to prevent blocking operations.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when senderId, userId, or message is null</exception>
    /// <exception cref="ArgumentException">Thrown when senderId, userId, or message is empty or contains only whitespace</exception>
    Task<bool> SendSms(string senderId, string userId, string message);
}
