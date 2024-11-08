using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // UserRepository extends the generic Repository to provide CRUD operations for User.
    // It implements IUserRepository to handle user-specific queries like getting by username, filtering by role, etc.
    public class UserRepository : Repository<User>, IUserRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public UserRepository(TondForooshContext context) : base(context) { }

        // Retrieves a user by their username asynchronously.
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Username == username);  // Find the first user with the specified username.
        }

        // Retrieves all users with a specific role asynchronously.
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(UserRole role)
        {
            return await _dbSet
                .Where(u => u.Role == role)  // Filter users by their role.
                .ToListAsync();  // Return the matching users as a list.
        }

        // Checks if a user with the specified username exists asynchronously.
        public async Task<bool> UserExistsAsync(string username)
        {
            return await _dbSet
                .AnyAsync(u => u.Username == username);  // Check if any user exists with the given username.
        }
    }
}
