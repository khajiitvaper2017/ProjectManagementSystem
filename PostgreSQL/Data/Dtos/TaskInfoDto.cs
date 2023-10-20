namespace PostgreSQL.Data.Dtos;

public sealed record TaskInfoDto
{
    public string Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public string? ProjectId { get; set; }
}
