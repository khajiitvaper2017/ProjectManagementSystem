using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Data.Repositories.User;

public sealed class UserRepository : IUserRepository
{
    private readonly ProjectManagementDbContext _context;
    
    public UserRepository(ProjectManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Entity.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<Entity.User?> FindSingle(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(p => p.Email == email);
    }

}