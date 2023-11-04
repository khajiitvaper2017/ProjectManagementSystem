using PostgreSQL.Data.Entity;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.UnitOfWork;

namespace PostgreSQL.CQRS.User.Queries.GetById;

public sealed class UserGetByIdQueryHandler : IUserGetByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UserGetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<UserEntity?> Handle(UserGetByIdQuery query)
    {
        var projectRepository = _unitOfWork.Repository<UserEntity>() as GenericRepository<UserEntity>;

        if (projectRepository is null)
        {
            throw new NullReferenceException(nameof(projectRepository));
        }

        var project = projectRepository.GetById(query.Id);
            
        return Task.FromResult(project);
    }
}