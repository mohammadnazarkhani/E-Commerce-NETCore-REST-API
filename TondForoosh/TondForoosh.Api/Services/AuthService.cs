using TondForoosh.Api.Entities;
using TondForoosh.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TondForoosh.Api.Data;

namespace TondForoosh.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;
        private readonly TondForooshContext _context;
        private readonly IPasswordHasherService _passwordHasher;

        // Constructor to inject dependencies
        public AuthService(TokenGenerator tokenGenerator, IConfiguration configuration, TondForooshContext context, IPasswordHasherService passwordHasher)
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
            _context = context;
            _passwordHasher = passwordHasher;  // Inject password hasher service
        }

        // Authenticate the user and return a JWT token
        public string Authenticate(User usr)
        {
            // Find user from the database
            var user = _context.Users.FirstOrDefault(u => u.Username == usr.Username);

            // If user not found or password is incorrect, return null
            if (user == null || !_passwordHasher.VerifyPassword(user.Password, usr.Password)) // Use VerifyPassword for checking hashed password
            {
                return null; // Invalid username or password
            }

            // Generate JWT token for the authenticated user
            return _tokenGenerator.GenerateToken(user);
        }

        // Generate JWT token for a new user during registration
        public string GenerateTokenForNewUser(User usr)
        {
            return _tokenGenerator.GenerateToken(usr); // Use TokenGenerator to generate a token for the new user
        }

        // Validate the JWT token
        public bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);

                // Validate the token
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                return true; // Token is valid
            }
            catch
            {
                return false; // Token is invalid
            }
        }
    }
}
