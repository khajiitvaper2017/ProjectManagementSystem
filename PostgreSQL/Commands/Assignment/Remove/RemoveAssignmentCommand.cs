using PostgreSQL.Data;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Commands.Assignment.Remove;

public sealed class RemoveAssignmentCommand : IRemoveAssignmentCommand
{
    private readonly ProjectManagementDbContext _context;
    public RemoveAssignmentCommand(ProjectManagementDbContext context)
    {
        _context = context;
    }
    public async System.Threading.Tasks.Task ExecuteAsync(Guid data)
    {
        AssignmentEntity assignment = await _context.Assignments.FindAsync(data);
        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();
    }
}