namespace PostgreSQL.Data.Entity;
public sealed class UserEntity : AbstractEntity.Entity, IEmailUser
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

    public Task ReceieveEmailAsync(string subject, string message, string sender)
    {
        Console.WriteLine($"Email sent to {Email} from {sender}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
        return Task.CompletedTask;
    }
}
