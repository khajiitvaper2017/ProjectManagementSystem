using PostgreSQL.Data;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Commands.Project.Remove
{
    public sealed class RemoveProjectCommand : IRemoveProjectCommand
    {
        private readonly ProjectManagementDbContext _context;
        public RemoveProjectCommand(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task ExecuteAsync(Guid data)
        {
            ProjectEntity project = await _context.Projects.FindAsync(data);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
