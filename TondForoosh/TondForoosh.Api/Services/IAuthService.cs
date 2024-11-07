namespace TondForoosh.Api.Services
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
        bool ValidateToken(string token);
    }
}
