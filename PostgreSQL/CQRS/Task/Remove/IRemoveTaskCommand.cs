using PostgreSQL.CQRS.Core;

namespace PostgreSQL.CQRS.Task.Remove
{
    public interface IRemoveTaskCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
