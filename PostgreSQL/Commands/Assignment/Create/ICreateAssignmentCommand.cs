using PostgreSQL.Commands.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.Commands.Assignment.Create;

public interface ICreateAssignmentCommand : INoResponseAsyncCommand<AssignmentInfoDto>
{
}