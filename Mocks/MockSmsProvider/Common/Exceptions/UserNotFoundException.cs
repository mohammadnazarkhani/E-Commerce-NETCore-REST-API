using System;

namespace MockSmsProvider.Common.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a requested user cannot be found in the system.
/// </summary>
/// <remarks>
/// This exception is typically thrown when attempting to perform operations on a user
/// that does not exist in the database or system context.
/// </remarks>
public class UserNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserNotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error. This message is passed to the base Exception class.</param>
    public UserNotFoundException(string? message) : base(message)
    {
    }
}
