using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQL.CQRS.Core.Query;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.Project.Queries.GetById
{
    public interface IProjectGetByIdQueryHandler : 
        IQueryHandler<ProjectGetByIdQuery, ProjectEntity?>
    {

    }
}
