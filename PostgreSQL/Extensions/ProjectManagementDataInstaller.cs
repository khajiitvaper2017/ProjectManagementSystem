using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostgreSQL.Data;

namespace PostgreSQL.Extensions;

public static class ProjectManagementDataInstaller
{
    public static IServiceCollection AddProjectManagementData(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContextPool<ProjectManagementDbContext>(options =>
            options.UseNpgsql(connectionString,
                               builder => builder.MigrationsAssembly("PostgreSQL")));
        return services;
    }
}