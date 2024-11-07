using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Services
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;

        // Constructor to inject IConfiguration
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Method to generate the JWT Token
        public string GenerateToken(User user, List<Claim>? additionalClaims = null)
        {
            // Read settings from appsettings.json
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expiryMinutes = Convert.ToInt32(_configuration["JwtSettings:ExpiryMinutes"]);

            // Create claims based on the user info (user model)
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),               // Subject (Username)
                new Claim(JwtRegisteredClaimNames.Email, user.Username),              // Email claim
                new Claim(ClaimTypes.Role, user.Role.ToString())                      // Role claim
            };

            // Add any additional claims passed as a parameter
            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims);
            }

            // Define the signing key (Symmetric Security Key)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Define signing credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the token descriptor with claims, signing credentials, etc.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),  // Expiry time
                Issuer = issuer,                                     // Issuer
                Audience = audience,                                 // Audience
                SigningCredentials = credentials                     // Signing credentials
            };

            // Create the token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);  // Create the JWT token

            // Return the string representation of the token
            return tokenHandler.WriteToken(token);
        }
    }
}
