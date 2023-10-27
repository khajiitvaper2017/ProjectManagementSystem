using PostgreSQL.Data;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Commands.Comment.Create;

public sealed class CreateCommentCommand : ICreateCommentCommand
{
    private readonly ProjectManagementDbContext _context;
    public CreateCommentCommand(ProjectManagementDbContext context)
    {
        _context = context;
    }
    public async System.Threading.Tasks.Task ExecuteAsync(CommentInfoDto dto)
    {
        CommentEntity comment = new CommentEntity
        {
            Id = dto.Id,
            UserId = dto.UserId,
            TaskId = dto.TaskId,
            Date = dto.Date,
            Text = dto.Text,
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }
}