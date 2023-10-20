using PostgreSQL.Commands.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.Commands.User.Create
{
    public interface ICreateUserCommand : INoResponseAsyncCommand<UserInfoDto>
    {
    }
}
