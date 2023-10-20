namespace PostgreSQL.Data.Entity;

public partial class ProjectEntity
{
    public string Id { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
