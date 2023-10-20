using PostgreSQL.Commands.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.Commands.Comment.Create
{
    public interface ICreateCommentCommand : INoResponseAsyncCommand<CommentInfoDto>
    {
    }
}
