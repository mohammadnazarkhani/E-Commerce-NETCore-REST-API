using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Services;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Data;

namespace TondForoosh.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;
        private readonly TondForooshContext _context; // Inject DbContext for accessing Users table

        // Constructor to inject dependencies
        public AuthService(TokenGenerator tokenGenerator, IConfiguration configuration, TondForooshContext context)
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
            _context = context; // Assign the DbContext
        }

        // Authenticate the user and return a JWT token
        public string Authenticate(string username, string password)
        {
            // Find user from the database
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            // If user not found or password is incorrect, return null
            if (user == null || user.Password != password)
            {
                return null; // Invalid username or password
            }

            // Generate JWT token for the authenticated user
            return _tokenGenerator.GenerateToken(user);
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
