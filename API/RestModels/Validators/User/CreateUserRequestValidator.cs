using API.RestModels.User;
using FluentValidation;

namespace API.RestModels.Validators.User;

public sealed class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(r => r.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage("First name is required");
        
        RuleFor(r => r.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Last name is required");

        RuleFor(r => r.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Correct Email is required");

        RuleFor(r => r.Phone)
            .NotNull()
            .NotEmpty()
            .WithMessage("Phone is required");
    }
}