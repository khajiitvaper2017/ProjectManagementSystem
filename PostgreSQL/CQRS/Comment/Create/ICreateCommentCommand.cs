using PostgreSQL.CQRS.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.CQRS.Comment.Create
{
    public interface ICreateCommentCommand : INoResponseAsyncCommand<CommentInfoDto>
    {
    }
}
