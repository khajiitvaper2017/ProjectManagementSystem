using PostgreSQL.Commands.Core;

namespace PostgreSQL.Commands.Project.Remove
{
    public interface IRemoveProjectCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
