namespace PostgreSQL.Data.Dtos;

public sealed record AssignmentInfoDto
{
    public DateTime? Date { get; set; }

    public Guid? TaskId { get; set; }

    public Guid? UserId { get; set; }
}
