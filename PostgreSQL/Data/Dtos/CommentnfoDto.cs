namespace PostgreSQL.Data.Dtos;

public sealed record CommentInfoDto
{
    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public Guid? TaskId { get; set; }

    public Guid? UserId { get; set; }
}
