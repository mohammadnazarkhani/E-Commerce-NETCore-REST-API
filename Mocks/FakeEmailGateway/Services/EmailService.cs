using FakeEmailGateway.Data.UnitOfWork;
using FakeEmailGateway.Models;
using FakeEmailGateway.Models.DTOs;
using FakeEmailGateway.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FakeEmailGateway.Services;

public class EmailService : ServiceBase
{
    public EmailService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    /// <summary>
    /// Sends an email from one user to another
    /// </summary>
    /// <param name="emailDto">Contains email details including sender, receiver, subject, and body</param>
    /// <returns>True if email was sent successfully, false otherwise</returns>
    public async Task<bool> SendEmailAsync(SendEmailDto emailDto)
    {
        if (emailDto == null || string.IsNullOrEmpty(emailDto.ReceiverEmail) || 
            string.IsNullOrEmpty(emailDto.SenderEmail) || string.IsNullOrEmpty(emailDto.Body))
            return false;

        try
        {
            var sender = await UnitOfWork.UsersRepo.Query
                .Include(u => u.Outbox)
                .FirstOrDefaultAsync(u => u.EmailAddress.Equals(emailDto.SenderEmail, 
                    StringComparison.OrdinalIgnoreCase));

            var receiver = await UnitOfWork.UsersRepo.Query
                .Include(u => u.Inbox)
                .FirstOrDefaultAsync(u => u.EmailAddress.Equals(emailDto.ReceiverEmail, 
                    StringComparison.OrdinalIgnoreCase));

            if (sender?.Outbox == null || receiver?.Inbox == null)
                return false;

            var email = new Email
            {
                Subject = emailDto.Subject,
                Body = emailDto.Body,
                SenderOutboxId = sender.Outbox.Id,
                ReceiverInboxId = receiver.Inbox.Id,
                CreationDate = DateTime.UtcNow
            };

            await UnitOfWork.EmailsRepo.AddAsync(email);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false;
        }
    }

    /// <summary>
    /// Retrieves all emails in a user's inbox
    /// </summary>
    /// <param name="userEmail">Email address of the user</param>
    /// <returns>List of emails in the user's inbox</returns>
    public async Task<IEnumerable<Email>> GetInboxEmailsAsync(string userEmail)
    {
        try
        {
            var user = await UnitOfWork.UsersRepo.Query
                .Include(u => u.Inbox)
                .FirstOrDefaultAsync(u => u.EmailAddress.Equals(userEmail, 
                    StringComparison.OrdinalIgnoreCase));

            if (user?.Inbox == null)
                return Enumerable.Empty<Email>();

            return await UnitOfWork.EmailsRepo.Query
                .Where(e => e.ReceiverInboxId == user.Inbox.Id)
                .Include(e => e.SenderOutbox)
                    .ThenInclude(o => o!.User)
                .OrderByDescending(e => e.CreationDate)
                .ToListAsync();
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return Enumerable.Empty<Email>();
        }
    }

    /// <summary>
    /// Retrieves all emails in a user's outbox
    /// </summary>
    /// <param name="userEmail">Email address of the user</param>
    /// <returns>List of emails in the user's outbox</returns>
    public async Task<IEnumerable<Email>> GetOutboxEmailsAsync(string userEmail)
    {
        try
        {
            var user = await UnitOfWork.UsersRepo.Query
                .Include(u => u.Outbox)
                .FirstOrDefaultAsync(u => u.EmailAddress.Equals(userEmail, 
                    StringComparison.OrdinalIgnoreCase));

            if (user?.Outbox == null)
                return Enumerable.Empty<Email>();

            return await UnitOfWork.EmailsRepo.Query
                .Where(e => e.SenderOutboxId == user.Outbox.Id)
                .Include(e => e.ReceiverInbox)
                    .ThenInclude(i => i!.User)
                .OrderByDescending(e => e.CreationDate)
                .ToListAsync();
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return Enumerable.Empty<Email>();
        }
    }

    /// <summary>
    /// Gets a specific email by its ID
    /// </summary>
    /// <param name="emailId">ID of the email to retrieve</param>
    /// <returns>The email if found, null otherwise</returns>
    public async Task<Email?> GetEmailByIdAsync(Guid emailId)
    {
        try
        {
            return await UnitOfWork.EmailsRepo.Query
                .Include(e => e.SenderOutbox)
                    .ThenInclude(o => o!.User)
                .Include(e => e.ReceiverInbox)
                    .ThenInclude(i => i!.User)
                .FirstOrDefaultAsync(e => e.Id == emailId);
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return null;
        }
    }
}