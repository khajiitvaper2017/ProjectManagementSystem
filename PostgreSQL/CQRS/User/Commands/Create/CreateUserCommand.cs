using PostgreSQL.CQRS.Base.Command;

namespace PostgreSQL.CQRS.User.Commands.Create;

public sealed record CreateUserCommand : ICommand
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }

    public CreateUserCommand(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
    
}