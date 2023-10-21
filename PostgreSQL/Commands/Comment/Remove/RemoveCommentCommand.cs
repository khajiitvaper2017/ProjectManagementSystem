using PostgreSQL.Data;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Commands.Comment.Remove
{
    public sealed class RemoveCommentCommand : IRemoveCommentCommand
    {
        private readonly ProjectManagementDbContext _context;
        public RemoveCommentCommand(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task ExecuteAsync(Guid data)
        {
            CommentEntity comment = await _context.Comments.FindAsync(data);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
