namespace PostgreSQL.Data.Entity;

public partial class CommentEntity
{
    public string Id { get; set; }

    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public string? TaskId { get; set; }

    public string? UserId { get; set; }

    public virtual TaskEntity? Task { get; set; }

    public virtual UserEntity? User { get; set; }
}
