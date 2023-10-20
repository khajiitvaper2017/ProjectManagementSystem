namespace PostgreSQL.Data.Dtos;

public sealed record AssignmentInfoDto
{
    public string Id { get; set; }

    public DateTime? Date { get; set; }

    public string? TaskId { get; set; }

    public string? UserId { get; set; }
}
