using PostgreSQL.CQRS.Base.Query;
using PostgreSQL.Dtos;

namespace PostgreSQL.CQRS.User.Queries.FindUser;

public interface IFindUserQueryHandler : IQueryHandler<FindUserQuery, UserInfoDto?>
{
    
}