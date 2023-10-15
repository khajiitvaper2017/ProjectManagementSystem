using PostgreSQL.CQRS.Base.Command;

namespace PostgreSQL.CQRS.User.Commands.Create;

public interface ICreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    
}