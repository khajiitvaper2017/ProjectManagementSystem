using PostgreSQL.CQRS.Core;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.CQRS.Project.Create
{
    public interface ICreateProjectCommand : INoResponseAsyncCommand<ProjectInfoDto>
    {
    }
}
