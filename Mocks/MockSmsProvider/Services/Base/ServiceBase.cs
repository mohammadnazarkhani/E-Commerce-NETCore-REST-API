using System;
using MockSmsProvider.Data;

namespace MockSmsProvider.Services.Base;

public class ServiceBase
{
    private ApplicationDbContext _context;

    public ServiceBase(ApplicationDbContext context)
    {
        _context = context;
    }
}
