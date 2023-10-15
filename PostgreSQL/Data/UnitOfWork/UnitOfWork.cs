using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Storage;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.Repositories.Factory;

namespace PostgreSQL.Data.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ProjectManagementDbContext _context;
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly ConcurrentDictionary<Type, object> _repositories;

    public UnitOfWork(ProjectManagementDbContext context, IRepositoryFactory repositoryFactory)
    {
        _context = context;
        _repositoryFactory = repositoryFactory;
        _repositories = new ConcurrentDictionary<Type, object>();
    }
    
    public async Task Commit()
    {
        await using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            
            throw;
        }
    }

    public IRepository Repository<TEntity>() where TEntity : class
    {
        if (_repositories.TryGetValue(typeof(TEntity), out object? repository)) 
            return (IRepository)repository;

        repository = _repositoryFactory.Instantiate<TEntity>(_context);
        _repositories.TryAdd(typeof(TEntity), repository);

        return (IRepository)repository;
    }
    
    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}