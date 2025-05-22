using System;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using MockSmsProvider.Data;
using MockSmsProvider.Models;
using MockSmsProvider.Services.Base;

namespace MockSmsProvider.Services;

public class SmsService : ServiceBase
{
    protected InboxService _inboxServices;

    public SmsService(ApplicationDbContext context, InboxService inboxServices) : base(context)
    {
        _inboxServices = inboxServices;
    }

    public async Task<bool> SendSms(string senderId, string userId, string message)
    {
        try
        {
            var receiverInbox = await _inboxServices.GetUserInbox(userId);

            Sms sms = new()
            {
                Id = new Guid(),
                Message = message,
                InboxId = receiverInbox.Id,
                SenderId = senderId
            };

            receiverInbox.Messages.Add(sms);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }

        return true;
    }
}
