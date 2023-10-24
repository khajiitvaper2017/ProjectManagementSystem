namespace PostgreSQL.CQRS.Core
{
    public interface INoResponseAsyncCommand<in TData>
    {
        Task ExecuteAsync(TData data);
    }
}
