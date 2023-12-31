﻿using PostgreSQL.CQRS.Core.Query;

namespace PostgreSQL.CQRS.Project.Queries.GetById;

public sealed class ProjectGetByIdQuery : IQuery
{
    public Guid Id { get; set; }

    public ProjectGetByIdQuery(Guid id)
    {
        Id = id;
    }
}