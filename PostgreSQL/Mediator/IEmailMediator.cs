using PostgreSQL.Data.Entity;

namespace PostgreSQL.Mediator;

public interface IEmailMediator
{
    Task SendEmailAsync(string email, string subject, string message);

    Task SendEmailToAllAsync(string subject, string message);
    
    void AddReceiver(IEmailUser emailUser);
}