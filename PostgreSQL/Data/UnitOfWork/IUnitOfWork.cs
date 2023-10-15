using PostgreSQL.Data.Repositories;

namespace PostgreSQL.Data.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    Task Commit();
    IRepository Repository<TEntity>() where TEntity : class;
}