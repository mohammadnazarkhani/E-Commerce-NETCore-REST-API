using System;
using MockSmsProvider.Models;

namespace MockSmsProvider.Services.Interfaces;

public interface IInboxService
{
    Task<List<Sms>> GetUserInboxMessagesByUserId(string userId);
    Task<Inbox> GetUserInbox(string userId);
}
