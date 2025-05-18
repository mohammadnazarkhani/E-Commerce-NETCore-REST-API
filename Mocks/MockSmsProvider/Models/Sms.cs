using System;

namespace MockSmsProvider.Models;

public class Sms
{
    public required Guid Id { get; set; }
    public required string Message { get; set; }
}
