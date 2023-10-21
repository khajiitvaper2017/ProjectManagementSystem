namespace PostgreSQL.Data.Entity;

public sealed class CommentEntity : AbstractEntity.Entity
{
    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public Guid? TaskId { get; set; }

    public Guid? UserId { get; set; }

    public TaskEntity? Task { get; set; }

    public UserEntity? User { get; set; }
}
