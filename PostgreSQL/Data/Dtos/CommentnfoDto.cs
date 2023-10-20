namespace PostgreSQL.Data.Dtos;

public sealed record CommentInfoDto
{
    public string Id { get; set; }

    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public string? TaskId { get; set; }

    public string? UserId { get; set; }
}
