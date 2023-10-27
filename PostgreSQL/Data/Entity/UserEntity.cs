namespace PostgreSQL.Data.Entity;

public sealed class UserEntity : AbstractEntity.Entity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public ICollection<AssignmentEntity> Assignments { get; set; } = new List<AssignmentEntity>();

    public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}
