using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQL.CQRS.Core.Query;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.Repositories.Project;
using PostgreSQL.Data.UnitOfWork;

namespace PostgreSQL.CQRS.Project.Queries.GetById
{
    public sealed class ProjectGetByIdQueryHandler : IProjectGetByIdQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ProjectEntity?> Handle(ProjectGetByIdQuery query)
        {
            var projectRepository = _unitOfWork.Repository<ProjectEntity>() as GenericRepository<ProjectEntity>;

            if (projectRepository is null)
            {
                throw new NullReferenceException(nameof(projectRepository));
            }

            var project = projectRepository.GetById(query.Id);
            
            return Task.FromResult(project);
        }
    }
}
