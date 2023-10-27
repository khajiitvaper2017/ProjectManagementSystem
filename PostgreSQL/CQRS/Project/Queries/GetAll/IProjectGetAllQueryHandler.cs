using PostgreSQL.CQRS.Core.Query;
using PostgreSQL.CQRS.Project.Queries.GetById;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.Project.Queries.GetAll
{
    public interface IProjectGetAllQueryHandler : 
        IQueryHandler<ProjectGetAllQuery, IEnumerable<ProjectEntity>?>
    {

    }
}
