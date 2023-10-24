using PostgreSQL.CQRS.Core;

namespace PostgreSQL.CQRS.Comment.Remove
{
    public interface IRemoveCommentCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
