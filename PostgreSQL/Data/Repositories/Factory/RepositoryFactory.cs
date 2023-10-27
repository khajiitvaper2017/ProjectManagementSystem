using PostgreSQL.Data.Repositories.User;
using PostgreSQL.Exceptions;

namespace PostgreSQL.Data.Repositories.Factory;

public sealed class RepositoryFactory : IRepositoryFactory
{
    public IRepository Instantiate<TEntity>(ProjectManagementDbContext context) where TEntity : class
    {
        return new GenericRepository<TEntity>(context);
    }
}