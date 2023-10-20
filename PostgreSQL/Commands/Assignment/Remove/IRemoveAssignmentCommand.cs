using PostgreSQL.Commands.Core;

namespace PostgreSQL.Commands.Assignment.Remove
{
    public interface IRemoveAssignmentCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
