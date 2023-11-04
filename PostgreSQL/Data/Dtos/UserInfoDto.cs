namespace PostgreSQL.Data.Dtos;

public sealed record UserInfoDto
{
    public Guid Id { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Phone { get; init; }
}