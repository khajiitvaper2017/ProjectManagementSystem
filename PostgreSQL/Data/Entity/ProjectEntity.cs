namespace PostgreSQL.Data.Entity;

public sealed class ProjectEntity : AbstractEntity.Entity
{
    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
