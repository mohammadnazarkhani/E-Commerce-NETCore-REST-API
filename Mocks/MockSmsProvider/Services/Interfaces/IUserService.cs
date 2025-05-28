using System;

namespace MockSmsProvider.Services.Interfaces;

/// <summary>
/// Provides user authentication and management functionality.
/// This service handles user sign-in operations in the mock SMS provider system.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Authenticates and signs in a user with the specified ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user attempting to sign in.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// Returns true if the sign-in was successful; otherwise, false.
    /// </returns>
    Task<bool> SingInUser(string id);
}
