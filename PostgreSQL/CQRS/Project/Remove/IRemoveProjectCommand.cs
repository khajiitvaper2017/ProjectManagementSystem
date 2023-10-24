using PostgreSQL.CQRS.Core;

namespace PostgreSQL.CQRS.Project.Remove
{
    public interface IRemoveProjectCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
