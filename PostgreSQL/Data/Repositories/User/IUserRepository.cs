namespace PostgreSQL.Data.Repositories.User;

public interface IUserRepository : IRepository
{
    Task Create(Entity.UserEntity userEntity);
    Task<Entity.UserEntity?> FindSingle(Guid id);
}