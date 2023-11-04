using PostgreSQL.Commands.Core;

namespace PostgreSQL.Commands.Comment.Remove;

public interface IRemoveCommentCommand : INoResponseAsyncCommand<Guid>
{
}