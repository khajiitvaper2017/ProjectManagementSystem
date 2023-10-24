using PostgreSQL.Data;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.User.Create
{
    public sealed class CreateUserCommand : ICreateUserCommand
    {
        private readonly ProjectManagementDbContext _context;
        public CreateUserCommand(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task ExecuteAsync(UserInfoDto dto)
        {
            UserEntity user = new UserEntity
            {
                Id = dto.Id,
                Email = dto.Email,
                Phone = dto.Phone,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
