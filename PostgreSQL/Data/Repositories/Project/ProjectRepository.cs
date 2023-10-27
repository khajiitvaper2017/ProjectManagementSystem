using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Data.Repositories.Project;

public sealed class ProjectRepository : IProjectRepository
{
    private readonly ProjectManagementDbContext _context;
    
    public ProjectRepository(ProjectManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Entity.ProjectEntity projectEntity)
    {
        await _context.Projects.AddAsync(projectEntity);
    }

    public async Task<Entity.ProjectEntity?> FindSingle(Guid id)
    {
        return await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);
    }
}