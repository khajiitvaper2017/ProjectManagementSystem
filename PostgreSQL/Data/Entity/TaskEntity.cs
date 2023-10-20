namespace PostgreSQL.Data.Entity;

public sealed class TaskEntity : AbstractEntity.Entity
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public ICollection<AssignmentEntity> Assignments { get; set; } = new List<AssignmentEntity>();

    public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();

    public Guid? ProjectId { get; set; }

    public ProjectEntity? Project { get; set; }
}
