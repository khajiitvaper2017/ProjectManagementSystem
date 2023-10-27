using PostgreSQL.CQRS.Project.Queries.GetById;
using PostgreSQL.Data.Entity;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.UnitOfWork;

namespace PostgreSQL.CQRS.Project.Queries.GetAll
{
    public sealed class ProjectGetAllQueryHandler : IProjectGetAllQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectGetAllQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<IEnumerable<ProjectEntity>?> Handle(ProjectGetAllQuery query = null)
        {
            var projectRepository = _unitOfWork.Repository<ProjectEntity>() as GenericRepository<ProjectEntity>;

            if (projectRepository is null)
            {
                throw new NullReferenceException(nameof(projectRepository));
            }

            var projects = projectRepository.GetAll();

            return Task.FromResult(projects);
        }
    }
}
