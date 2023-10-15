using PostgreSQL.CQRS.Base.Command;
using PostgreSQL.Data.Repositories.User;
using PostgreSQL.Data.Entity;
using PostgreSQL.Data.UnitOfWork;

namespace PostgreSQL.CQRS.User.Commands.Create;

public sealed class CreateUserCommandHandler : ICreateUserCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    async System.Threading.Tasks.Task ICommandHandler<CreateUserCommand>.Handle(CreateUserCommand command)
    {
        DateTime now = DateTime.UtcNow;

        Data.Entity.User user = new Data.Entity.User()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Phone = command.Phone,
        };

        await ((IUserRepository) _unitOfWork.Repository<Data.Entity.User>()).Create(user);

        await _unitOfWork.Commit();
    }
}