namespace PostgreSQL.Data.Repositories.Factory;

public interface IRepositoryFactory
{
    IRepository Instantiate<TEntity>(ProjectManagementDbContext context) where TEntity : class;
}