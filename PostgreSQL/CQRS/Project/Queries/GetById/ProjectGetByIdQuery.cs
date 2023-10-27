using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQL.CQRS.Core.Query;

namespace PostgreSQL.CQRS.Project.Queries.GetById
{
    public sealed class ProjectGetByIdQuery : IQuery
    {
        public Guid Id { get; set; }

        public ProjectGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
