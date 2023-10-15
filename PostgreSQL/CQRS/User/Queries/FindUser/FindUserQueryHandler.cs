using PostgreSQL.Data.Repositories.User;
using PostgreSQL.Dtos;

namespace PostgreSQL.CQRS.User.Queries.FindUser;

public sealed class FindUserQueryHandler : IFindUserQueryHandler
{
    private readonly IUserRepository _repository;

    public FindUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<UserInfoDto?> Handle(FindUserQuery query)
    {
        Data.Entity.User? entity = await _repository.FindSingle(query.Email);

        return entity != null ? new UserInfoDto(entity.Id, entity.Email, entity.FirstName, 
            entity.LastName, entity.Phone) : default;
    }
}