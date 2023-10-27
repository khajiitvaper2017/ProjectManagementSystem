using PostgreSQL.CQRS.Core.Command;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.User.Commands.Create;

public interface IUserCreateCommandHandler : ICommandHandler<UserCreateCommand>
{

}