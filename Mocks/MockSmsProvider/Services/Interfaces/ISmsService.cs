using System;

namespace MockSmsProvider.Services.Interfaces;

public interface ISmsService
{
    Task<bool> SendSms(string senderId, string userId, string message);
}
