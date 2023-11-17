using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
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

        _context.Projects.Load();
        _context.Tasks.Load();
        _context.Assignments.Load();
        _context.Users.Load();
        _context.Comments.Load();
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
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