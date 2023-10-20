namespace PostgreSQL.Data.Entity;

public partial class UserEntity
{
    public string Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<AssignmentEntity> Assignments { get; set; } = new List<AssignmentEntity>();

    public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
}
