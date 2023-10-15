using PostgreSQL.CQRS.Base.Query;

namespace PostgreSQL.CQRS.User.Queries.FindUser;

public sealed record FindUserQuery : IQuery
{
    public string Email { get; }

    public FindUserQuery(string email)
    {
        Email = email;
    }
}