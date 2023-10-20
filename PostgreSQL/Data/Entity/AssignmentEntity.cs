namespace PostgreSQL.Data.Entity;

public sealed class AssignmentEntity : AbstractEntity.Entity
{
    public DateTime? Date { get; set; }

    public Guid? TaskId { get; set; }

    public Guid? UserId { get; set; }

    public TaskEntity? Task { get; set; }

    public UserEntity? User { get; set; }
}
