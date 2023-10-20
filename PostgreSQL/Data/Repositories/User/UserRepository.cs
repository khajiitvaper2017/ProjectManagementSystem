using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Data.Repositories.User;

public sealed class UserRepository : IUserRepository
{
    private readonly ProjectManagementDbContext _context;
    
    public UserRepository(ProjectManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Entity.UserEntity userEntity)
    {
        await _context.Users.AddAsync(userEntity);
    }

    public async Task<Entity.UserEntity?> FindSingle(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(p => p.Email == email);
    }

}