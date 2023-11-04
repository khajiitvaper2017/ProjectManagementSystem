namespace PostgreSQL.Data.Repositories.Project;

public interface IProjectRepository : IRepository
{
    Task Create(Entity.ProjectEntity projectEntity);
    Task<Entity.ProjectEntity?> FindSingle(Guid id);
}