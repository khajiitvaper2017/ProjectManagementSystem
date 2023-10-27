using PostgreSQL.Data.Entity;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.UnitOfWork;

namespace PostgreSQL.CQRS.User.Commands.Create
{
    public sealed class UserCreateCommandHandler : IUserCreateCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UserCreateCommand command)
        {
            UserEntity user = new UserEntity
            {
                Id = new Guid(),
                Email = command.UserInfo.Email,
                Phone = command.UserInfo.Phone,
                FirstName = command.UserInfo.FirstName,
                LastName = command.UserInfo.LastName,
            };

            (_unitOfWork.Repository<UserEntity>() as GenericRepository<UserEntity>)?.Insert(user);
            await _unitOfWork.Commit();
        }
    }
}
