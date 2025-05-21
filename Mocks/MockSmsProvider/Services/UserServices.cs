using System;
using Microsoft.EntityFrameworkCore;
using MockSmsProvider.Data;
using MockSmsProvider.Models;

namespace MockSmsProvider.Services;

public class UserServices
{
    private ApplicationDbContext _context;

    public UserServices(ApplicationDbContext context)
    {
        _context = context;
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
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
