using Microsoft.Extensions.DependencyInjection;
using PostgreSQL.Data.Repositories.Factory;
using PostgreSQL.Data.Repositories.User;
using PostgreSQL.Data.UnitOfWork;

namespace PostgreSQL.Extensions;

public static class DataAccessInstaller
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>();
        
        services
            .AddSingleton<IRepositoryFactory, RepositoryFactory>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
            
        return services;
    }
}