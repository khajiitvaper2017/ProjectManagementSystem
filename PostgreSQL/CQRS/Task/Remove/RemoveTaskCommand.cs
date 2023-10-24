using PostgreSQL.Data;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.Task.Remove
{
    public sealed class RemoveTaskCommand : IRemoveTaskCommand
    {
        private readonly ProjectManagementDbContext _context;
        public RemoveTaskCommand(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task ExecuteAsync(Guid data)
        {
            TaskEntity task = await _context.Tasks.FindAsync(data);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
