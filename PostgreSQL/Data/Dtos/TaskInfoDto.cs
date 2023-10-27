namespace PostgreSQL.Data.Dtos;

public sealed record TaskInfoDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public Guid? ProjectId { get; set; }
}
