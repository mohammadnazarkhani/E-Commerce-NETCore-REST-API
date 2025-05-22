using System;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using MockSmsProvider.Common.Exceptions;
using MockSmsProvider.Data;
using MockSmsProvider.Models;
using MockSmsProvider.Services.Base;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Services;

public class InboxService : ServiceBase, IInboxService
{
    public InboxService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Guid> GetUserInboxId(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            throw new UserNotFoundException($"No user found by id of {userId}! Please first sign in the user.");

        var existingInbox = await _context.Inboxes.FirstOrDefaultAsync(i => i.UserId == userId);
        if (existingInbox != null)
            return existingInbox.Id;

        Inbox usrInbox = new()
        {
            Id = new Guid(),
            UserId = user.Id
        };

        await _context.Inboxes.AddAsync(usrInbox);
        await _context.SaveChangesAsync();

        return usrInbox.Id;
    }

    public async Task<Inbox> GetUserInbox(string userId)
    {
        var userInboxId = await GetUserInboxId(userId);

        var usrInbox = await _context.Inboxes.FirstOrDefaultAsync(i => i.Id == userInboxId);

        return usrInbox!;
    }

    public async Task<List<Sms>> GetUserInboxMessagesByUserId(string userId)
    {
        Guid userInboxId = await GetUserInboxId(userId);

        var userInbox = await _context.Inboxes
            .Include(i => i.Messages)
            .FirstOrDefaultAsync(i => i.Id == userInboxId);

        return userInbox?.Messages ?? new List<Sms>();
    }
}
