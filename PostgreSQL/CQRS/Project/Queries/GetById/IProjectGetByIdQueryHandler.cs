using PostgreSQL.CQRS.Core.Query;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.Project.Queries.GetById;

public interface IProjectGetByIdQueryHandler : 
    IQueryHandler<ProjectGetByIdQuery, ProjectEntity?>
{

}