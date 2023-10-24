using PostgreSQL.CQRS.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.CQRS.Task.Create
{
    public interface ICreateTaskCommand : INoResponseAsyncCommand<TaskInfoDto>
    {
    }
}
