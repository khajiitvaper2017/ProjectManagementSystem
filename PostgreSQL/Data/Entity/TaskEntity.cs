namespace PostgreSQL.Data.Entity;

public partial class TaskEntity
{
    public string Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<AssignmentEntity> Assignments { get; set; } = new List<AssignmentEntity>();

    public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();

    public string? ProjectId { get; set; }

    public virtual ProjectEntity? Project { get; set; }
}
