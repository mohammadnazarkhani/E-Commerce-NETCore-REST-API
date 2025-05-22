using System;

namespace MockSmsProvider.Services.Interfaces;

public interface IUserService
{
    Task<bool> SingInUser(string id);
}
