using PostgreSQL.Data.Repositories.User;
using PostgreSQL.Exceptions;

namespace PostgreSQL.Data.Repositories.Factory;

public sealed class RepositoryFactory : IRepositoryFactory
{
    public IRepository Instantiate<TEntity>(ProjectManagementDbContext context) where TEntity : class
    {
        return typeof(TEntity).Name switch
        {
            nameof(User) => new UserRepository(context),
            _ => throw new UnsupportedRepositoryTypeException(typeof(TEntity).Name)
        };
    }
}