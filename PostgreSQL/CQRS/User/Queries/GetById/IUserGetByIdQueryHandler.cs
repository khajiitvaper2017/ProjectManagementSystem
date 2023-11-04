using PostgreSQL.CQRS.Core.Query;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.CQRS.User.Queries.GetById;

public interface IUserGetByIdQueryHandler : 
    IQueryHandler<UserGetByIdQuery, UserEntity?>
{

}