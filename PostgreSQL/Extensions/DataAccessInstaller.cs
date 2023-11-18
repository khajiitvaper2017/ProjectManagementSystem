using Microsoft.Extensions.DependencyInjection;
using PostgreSQL.ChainOfResponsibility;
using PostgreSQL.Data.Repositories.Factory;
using PostgreSQL.Data.UnitOfWork;

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
}