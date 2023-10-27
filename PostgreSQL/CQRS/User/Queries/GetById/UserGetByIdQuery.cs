using PostgreSQL.CQRS.Core.Query;

namespace PostgreSQL.CQRS.User.Queries.GetById
{
    public sealed class UserGetByIdQuery : IQuery
    {
        public Guid Id { get; set; }

        public UserGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
