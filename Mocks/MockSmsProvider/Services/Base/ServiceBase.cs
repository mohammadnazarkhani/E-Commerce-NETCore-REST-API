using System;
using MockSmsProvider.Data;

namespace MockSmsProvider.Services.Base;

public class ServiceBase
{
    protected ApplicationDbContext _context;

    public ServiceBase(ApplicationDbContext context)
    {
        _context = context;
    }
}
