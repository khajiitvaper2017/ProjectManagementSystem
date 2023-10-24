using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQL.Data.UnitOfWork;
using PostgreSQL.CQRS.Task.Create;
using PostgreSQL.CQRS.Task.Remove;
using PostgreSQL.CQRS.Comment.Create;
using PostgreSQL.CQRS.Comment.Remove;
using PostgreSQL.CQRS.Assignment.Create;
using PostgreSQL.CQRS.Assignment.Remove;
using PostgreSQL.CQRS.User.Create;
using PostgreSQL.CQRS.User.Remove;
using PostgreSQL.CQRS.Project.Create;
using PostgreSQL.CQRS.Project.Remove;

namespace PostgreSQL.Extensions
{
    public static class CommandsInstaller 
    {
        public static IServiceCollection AddUserCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IRemoveUserCommand, RemoveUserCommand>();
            return services;
        }

        public static IServiceCollection AddProjectCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateProjectCommand, CreateProjectCommand>();
            services.AddScoped<IRemoveProjectCommand, RemoveProjectCommand>();
            return services;
        }

        public static IServiceCollection AddTaskCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateTaskCommand, CreateTaskCommand>();
            services.AddScoped<IRemoveTaskCommand, RemoveTaskCommand>();
            return services;
        }

        public static IServiceCollection AddAssignmentCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateAssignmentCommand, CreateAssignmentCommand>();
            services.AddScoped<IRemoveAssignmentCommand, RemoveAssignmentCommand>();
            return services;
        }

        public static IServiceCollection AddCommentCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateCommentCommand, CreateCommentCommand>();
            services.AddScoped<IRemoveCommentCommand, RemoveCommentCommand>();
            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddUserCommands();
            services.AddProjectCommands();
            services.AddTaskCommands();
            services.AddAssignmentCommands();
            services.AddCommentCommands();
            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
