namespace PostgreSQL.Data.Repositories.User;

public interface IUserRepository : IRepository
{
    Task Create(Entity.User user);
    Task<Entity.User?> FindSingle(string id);
}