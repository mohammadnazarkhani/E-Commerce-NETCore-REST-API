using System;
using FakeEmailGateway.Data.UnitOfWork;
using FakeEmailGateway.Models;
using FakeEmailGateway.Models.DTOs;
using FakeEmailGateway.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FakeEmailGateway.Services;

/// <summary>
/// Service for managing user-related operations such as registration and login.
/// This service interacts with the UnitOfWork to perform database operations.
/// </summary>
/// <param name="unitOfWork">Inject implemented instance of IUnitOfWork</param>
public class UserService : ServiceBase
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    /// <summary>
    /// Checks if the provided email is available for registration.
    /// This method queries the database to see if the email already exists.
    /// </summary>
    /// <param name="email">
    /// The email address to check for availability.
    /// It should not be null or empty.
    /// </param>
    /// <returns>
    /// Boolean indicating whether the email is available.
    /// Returns true if the email is not found in the database, false otherwise.
    /// </returns>
    public async Task<bool> IsEmailAvailableAsync(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        try
        {
            var user = await UnitOfWork.UsersRepo.Query
                .FirstOrDefaultAsync(u => u.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));
            return user == null;
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false; // Consider email unavailable if an error occurs
        }
    }

    /// <summary>
    /// Registers a new user with the provided details.
    /// This method checks if the email is available, hashes the password, and saves the user to the database.
    /// </summary>
    /// <param name="registerUserDto">
    /// registerUserDto contains the user's registration details.
    /// It should not be null, and must contain a valid email and password.
    /// </param>
    /// <returns>
    /// A boolean indicating whether the registration was successful.
    /// Returns true if the user was successfully registered, false otherwise.
    /// </returns>
    public async Task<bool> RegisterAsync(RegisterUserDto registerUserDto)
    {
        if (registerUserDto == null || string.IsNullOrEmpty(registerUserDto.Email) || string.IsNullOrEmpty(registerUserDto.Password))
            return false; // Invalid input

        try
        {
            if (!await IsEmailAvailableAsync(registerUserDto.Email))
                return false; // Email already exists

            // Create a new user entity
            var user = new User
            {
                EmailAddress = registerUserDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password),
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                PhoneNumber = registerUserDto.PhoneNumber
            };

            await UnitOfWork.UsersRepo.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false; // Registration failed due to an error
        }
    }

    /// <summary>
    /// Attempts to log in a user with the provided credentials.
    /// This method checks if the user exists and verifies the password.
    /// </summary>
    /// <param name="loginDto">
    /// Dto containing the user's login credentials.
    /// It should not be null, and must contain a valid email and password.
    /// </param>
    /// <returns>
    /// A boolean indicating whether the login was successful.
    /// Returns true if the email and password match an existing user, false otherwise.
    /// </returns>
    public async Task<bool> LoginAsync(LoginDto loginDto)
    {
        if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            return false; // Invalid input

        try
        {
            var user = await UnitOfWork.UsersRepo.Query
                .FirstOrDefaultAsync(u => u.EmailAddress.Equals(loginDto.Email, StringComparison.OrdinalIgnoreCase));
            if (user == null) return false; // User not found

            // Verify the password
            return BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false; // Login failed due to an error
        }
    }
}
