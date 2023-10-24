using PostgreSQL.CQRS.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.CQRS.Assignment.Create
{
    public interface ICreateAssignmentCommand : INoResponseAsyncCommand<AssignmentInfoDto>
    {
    }
}
