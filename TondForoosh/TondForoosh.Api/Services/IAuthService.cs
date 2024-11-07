using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Services
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
        string GenerateTokenForNewUser(User usr);
        bool ValidateToken(string token);
        User GetCurrentUser(); 
    }
}
