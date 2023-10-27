using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Data.Repositories;

public class GenericRepository<TEntity> : IRepository where TEntity : class
{
    private readonly ProjectManagementDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ProjectManagementDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public virtual TEntity? GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
        _dbSet.Add(entity);

        Update(entity);
    }

    public virtual void Delete(Guid id)
    {
        var entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);

        Update(entityToDelete);
    }

    public virtual void Delete(TEntity? entityToDelete)
    {
        if (entityToDelete is null)
        {
            return;
        }
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);

        Update(entityToDelete);
    }

    public virtual void Update(TEntity? entityToUpdate)
    {
        if (entityToUpdate is null)
        {
            return;
        }
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}