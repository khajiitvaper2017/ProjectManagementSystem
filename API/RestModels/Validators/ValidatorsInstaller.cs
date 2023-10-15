using API.RestModels.User;
using API.RestModels.Validators.User;
using FluentValidation;

namespace API.RestModels.Validators;

public static class ValidatorsInstaller
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
        
        return services;
    }
}