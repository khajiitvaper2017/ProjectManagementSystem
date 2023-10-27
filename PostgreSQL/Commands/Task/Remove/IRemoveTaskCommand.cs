using PostgreSQL.Commands.Core;

namespace PostgreSQL.Commands.Task.Remove;

public interface IRemoveTaskCommand : INoResponseAsyncCommand<Guid>
{
}