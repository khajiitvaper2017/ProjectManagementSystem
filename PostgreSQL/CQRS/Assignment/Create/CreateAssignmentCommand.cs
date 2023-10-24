using PostgreSQL.Commands.User.Create;
using PostgreSQL.Data;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Data.Entity;
using System.Threading.Tasks;
namespace PostgreSQL.CQRS.Assignment.Create
{
    public sealed class CreateAssignmentCommand : ICreateAssignmentCommand
    {
        private readonly ProjectManagementDbContext _context;
        public CreateAssignmentCommand(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task ExecuteAsync(AssignmentInfoDto dto)
        {
            AssignmentEntity assignment = new AssignmentEntity
            {
                Id = dto.Id,
                UserId = dto.UserId,
                TaskId = dto.TaskId,
                Date = dto.Date,
            };

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
        }
    }
}
