namespace PostgreSQL.Data.Dtos;

public sealed record ProjectInfoDto
{

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }
}