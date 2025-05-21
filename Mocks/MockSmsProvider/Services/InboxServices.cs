using System;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using MockSmsProvider.Common.Exceptions;
using MockSmsProvider.Data;
using MockSmsProvider.Models;
using MockSmsProvider.Services.Base;

namespace MockSmsProvider.Services;

public class InboxServices : ServiceBase
{
    public InboxServices(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Guid> GetUserInboxId(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            throw new UserNotFoundException($"No user found by id of {userId}! Please first sign in the user.");

        if (user.Inbox == null)
        {
            Inbox usrInbox = new()
            {
                Id = new Guid(),
                UserId = user.Id
            };

            user.Inbox = usrInbox;
        }

        return user.Inbox.Id;
    }

    public async Task<List<Sms>> GetUserInboxMessagesByUserId(string userId)
    {
        Guid userInboxId = await GetUserInboxId(userId);

        var userInbox = await _context.Inboxes.FirstOrDefaultAsync(i => i.Id == userInboxId);

        return userInbox?.Messages ?? new List<Sms>();
    }
}
