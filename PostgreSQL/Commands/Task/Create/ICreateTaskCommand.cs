using PostgreSQL.Commands.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.Commands.Task.Create
{
    public interface ICreateTaskCommand : INoResponseAsyncCommand<TaskInfoDto>
    {
    }
}
