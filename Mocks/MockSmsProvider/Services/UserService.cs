using System;
using Microsoft.EntityFrameworkCore;
using MockSmsProvider.Data;
using MockSmsProvider.Models;
using MockSmsProvider.Services.Base;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Services;

public class UserService : ServiceBase, IUserService
{
    public UserService(ApplicationDbContext context)
        : base(context)
    {

    }
    public async Task<bool> SingInUser(string id)
    {
        try
        {
            var userAcc = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (userAcc is not null)
                return true;

            userAcc = new User
            {
                Id = id
            };
            await _context.Users.AddAsync(userAcc);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
