using PostgreSQL.CQRS.Core;

namespace PostgreSQL.CQRS.Assignment.Remove
{
    public interface IRemoveAssignmentCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
