using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace MockSmsProvider.Models.DTOs;

public record SendSmsDto(
    [Required]
    string sender,
    [Required]
    string receiver,
    [Required]
    string message
);