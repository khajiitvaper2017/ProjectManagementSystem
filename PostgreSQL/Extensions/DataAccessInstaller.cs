using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.DependencyInjection;
using PostgreSQL.ChainOfResponsibility;
using PostgreSQL.Data.Repositories.Factory;
using PostgreSQL.Data.UnitOfWork;
using PostgreSQL.Mediator;

namespace PostgreSQL.Extensions;

public static class DataAccessInstaller
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        // Add logger
        services
            .AddSingleton<IRepositoryFactory, RepositoryFactory>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddSingleton<ILogger, Logger>();

        return services;
    }

    public static IServiceCollection AddEmailMediator(this IServiceCollection services)
    {
        var senderEmail = Environment.GetEnvironmentVariable("SENDER_EMAIL", EnvironmentVariableTarget.User);
        var senderPassword = Environment.GetEnvironmentVariable("SENDER_PASSWORD", EnvironmentVariableTarget.User);

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };

        var mailAddress = new MailAddress(senderEmail);

        services
            .AddSingleton<IEmailMediator, EmailMediator>(serviceProvider => new EmailMediator(smtpClient, mailAddress));

        return services;
    }
}