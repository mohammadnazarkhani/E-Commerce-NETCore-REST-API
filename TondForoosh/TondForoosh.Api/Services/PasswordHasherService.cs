using BCrypt.Net;

namespace TondForoosh.Api.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        // Hash the password using BCrypt
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verify the password against the hashed password
        public bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
