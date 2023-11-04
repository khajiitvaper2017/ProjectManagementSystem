using PostgreSQL.Commands.Core;

namespace PostgreSQL.Commands.User.Remove
{
    public interface IRemoveUserCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
