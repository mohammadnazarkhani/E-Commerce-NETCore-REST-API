using TondForoosh.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The IUserRepository extends the generic IRepository interface for User.
    // This interface can include additional methods specific to the User entity.
    public interface IUserRepository : IRepository<User>
    {
        // Example method to get a user by their username asynchronously.
        Task<User> GetUserByUsernameAsync(string username);

        // Example method to get all users with a specific role asynchronously.
        Task<IEnumerable<User>> GetUsersByRoleAsync(UserRole role);

        // Example method to check if a user exists by username.
        Task<bool> UserExistsAsync(string username);
    }
}
