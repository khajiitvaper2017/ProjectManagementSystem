using PostgreSQL.CQRS.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.CQRS.User.Create
{
    public interface ICreateUserCommand : INoResponseAsyncCommand<UserInfoDto>
    {
    }
}
