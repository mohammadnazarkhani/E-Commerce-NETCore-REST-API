using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Services
{
    public interface IAuthService
    {
        string Authenticate(User usr);
        string GenerateTokenForNewUser(User usr);
        bool ValidateToken(string token);
    }
}
