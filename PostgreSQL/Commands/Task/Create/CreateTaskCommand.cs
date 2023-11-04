using PostgreSQL.Data;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Commands.Task.Create;

public sealed class CreateTaskCommand : ICreateTaskCommand
{
    private readonly ProjectManagementDbContext _context;
    public CreateTaskCommand(ProjectManagementDbContext context)
    {
        _context = context;
    }

    public async System.Threading.Tasks.Task ExecuteAsync(TaskInfoDto dto)
    {
        TaskEntity task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Status = dto.Status,
            ProjectId = dto.ProjectId,
                
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }
}