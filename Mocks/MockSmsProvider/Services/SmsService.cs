using System;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using MockSmsProvider.Data;
using MockSmsProvider.Models;
using MockSmsProvider.Services.Base;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Services;

public class SmsService : ServiceBase, ISmsService
{
    protected IInboxService _inboxServices;

    public SmsService(ApplicationDbContext context, IInboxService inboxServices) : base(context)
    {
        _inboxServices = inboxServices;
    }

    public async Task<bool> SendSms(string senderId, string receiverId, string message)
    {
        try
        {
            var receiverInbox = await _inboxServices.GetUserInbox(receiverId);

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
