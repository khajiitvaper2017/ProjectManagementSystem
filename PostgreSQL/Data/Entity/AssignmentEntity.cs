namespace PostgreSQL.Data.Entity;

public sealed class AssignmentEntity : AbstractEntity.Entity
{
    public DateTime? Date { get; set; }

    public string? TaskId { get; set; }

    public string? UserId { get; set; }

    public TaskEntity? Task { get; set; }

    public UserEntity? User { get; set; }
}
