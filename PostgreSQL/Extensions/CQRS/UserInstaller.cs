using Microsoft.Extensions.DependencyInjection;
using PostgreSQL.CQRS.User.Commands.Create;
using PostgreSQL.CQRS.User.Queries.FindUser;

namespace PostgreSQL.Extensions.CQRS;

public static class UserInstaller
{
    public static IServiceCollection AddUserCommands(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateUserCommandHandler, CreateUserCommandHandler>();
        
        return services;
    }
    
    public static IServiceCollection AddUserQueries(this IServiceCollection services)
    {
        services
            .AddScoped<IFindUserQueryHandler, FindUserQueryHandler>();
        
        return services;
    }
}