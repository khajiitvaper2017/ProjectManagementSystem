namespace PostgreSQL.Data.Entity;

public partial class AssignmentEntity
{
    public string Id { get; set; }

    public DateTime? Date { get; set; }

    public string? TaskId { get; set; }

    public string? UserId { get; set; }

    public virtual TaskEntity? Task { get; set; }

    public virtual UserEntity? User { get; set; }
}
