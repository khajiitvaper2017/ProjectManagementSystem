namespace PostgreSQL.CQRS.Core
{
    public interface IAsyncCommand
    {
        Task ExecuteAsync();
    }

    public interface IAsyncCommand<TResult>
    {
        Task<TResult> ExecuteAsync();
    }

    public interface IAsyncCommand<in TData, TResult>
    {
        Task<TResult> ExecuteAsync(TData data);
    }
}
