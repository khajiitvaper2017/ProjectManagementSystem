using PostgreSQL.Data;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Commands.Project.Create;

public sealed class CreateProjectCommand : ICreateProjectCommand
{
    private readonly ProjectManagementDbContext _context;
    public CreateProjectCommand(ProjectManagementDbContext context)
    {
        _context = context;
    }
    public async System.Threading.Tasks.Task ExecuteAsync(ProjectInfoDto  dto)
    {
        ProjectEntity project = new ProjectEntity
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }
}