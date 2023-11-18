using PostgreSQL.Data.Entity;
using System.Net.Mail;

namespace PostgreSQL.Mediator;

public class EmailMediator : IEmailMediator
{
    private readonly SmtpClient _smtpClient;
    private readonly MailAddress _senderEmail;

    private readonly HashSet<IEmailUser> _receivers = new();
    public EmailMediator(SmtpClient smtpClient, MailAddress senderEmail)
    {
        _smtpClient = smtpClient;
        _senderEmail = senderEmail;
    }

    public void AddReceiver(IEmailUser emailUser)
    {
        _receivers.Add(emailUser);
    }
    public async Task SendEmailAsync(string receiverEmail, string subject, string message)
    {
        var mailMessage = new MailMessage(_senderEmail, new MailAddress(receiverEmail))
        {
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        await _smtpClient.SendMailAsync(mailMessage);
    }

    public async Task SendEmailToAllAsync(string subject, string message)
    {
        var mailMessage = new MailMessage(_senderEmail, _senderEmail)
        {
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        foreach (var receiver in _receivers)
        {
            mailMessage.To.Add(new MailAddress(receiver.Email));
        }

        await _smtpClient.SendMailAsync(mailMessage);

        foreach (var receiver in _receivers)
        {
            await receiver.ReceieveEmailAsync(subject, message, _senderEmail.Address);
        }
    }
}