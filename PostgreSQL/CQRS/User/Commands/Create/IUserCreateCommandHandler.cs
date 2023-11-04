using PostgreSQL.CQRS.Core.Command;

namespace PostgreSQL.CQRS.User.Commands.Create;

public interface IUserCreateCommandHandler : ICommandHandler<UserCreateCommand>
{

}