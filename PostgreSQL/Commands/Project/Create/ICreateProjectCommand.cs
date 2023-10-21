using PostgreSQL.Commands.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.Commands.Project.Create
{
    public interface ICreateProjectCommand : INoResponseAsyncCommand<ProjectInfoDto>
    {
    }
}
