using Microsoft.Extensions.DependencyInjection;

namespace PostgreSQL.Extensions.CQRS;

public static class CqrsInstaller
{
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        services
            .AddUserCommands()
            .AddUserQueries();
        
        return services;
    }
}