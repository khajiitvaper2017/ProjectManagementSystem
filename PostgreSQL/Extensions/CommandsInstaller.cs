using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL.Extensions
{
    public static class CommandsInstaller 
    {
        public static IServiceCollection AddUserCommands(this IServiceCollection services)
        {
            services.AddScoped<Commands.User.Create.ICreateUserCommand, Commands.User.Create.CreateUserCommand>();
            services.AddScoped<Commands.User.Remove.IRemoveUserCommand, Commands.User.Remove.RemoveUserCommand>();
            return services;
        }

        public static IServiceCollection AddProjectCommands(this IServiceCollection services)
        {
            services.AddScoped<Commands.Project.Create.ICreateProjectCommand, Commands.Project.Create.CreateProjectCommand>();
            services.AddScoped<Commands.Project.Remove.IRemoveProjectCommand, Commands.Project.Remove.RemoveProjectCommand>();
            
            services.AddScoped<CQRS.Project.Queries.GetById.IProjectGetByIdQueryHandler, CQRS.Project.Queries.GetById.ProjectGetByIdQueryHandler>();
            services.AddScoped<CQRS.Project.Queries.GetAll.IProjectGetAllQueryHandler, CQRS.Project.Queries.GetAll.ProjectGetAllQueryHandler>();
            return services;
        }

        public static IServiceCollection AddTaskCommands(this IServiceCollection services)
        {
            services.AddScoped<Commands.Task.Create.ICreateTaskCommand, Commands.Task.Create.CreateTaskCommand>();
            services.AddScoped<Commands.Task.Remove.IRemoveTaskCommand, Commands.Task.Remove.RemoveTaskCommand>();
            return services;
        }

        public static IServiceCollection AddAssignmentCommands(this IServiceCollection services)
        {
            services.AddScoped<Commands.Assignment.Create.ICreateAssignmentCommand, Commands.Assignment.Create.CreateAssignmentCommand>();
            services.AddScoped<Commands.Assignment.Remove.IRemoveAssignmentCommand, Commands.Assignment.Remove.RemoveAssignmentCommand>();
            return services;
        }

        public static IServiceCollection AddCommentCommands(this IServiceCollection services)
        {
            services.AddScoped<Commands.Comment.Create.ICreateCommentCommand, Commands.Comment.Create.CreateCommentCommand>();
            services.AddScoped<Commands.Comment.Remove.IRemoveCommentCommand, Commands.Comment.Remove.RemoveCommentCommand>();
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
    }
}
