namespace PostgreSQL.Commands.Core;

public interface IAsyncCommand
{
    System.Threading.Tasks.Task ExecuteAsync();
}

public interface IAsyncCommand<TResult>
{
    Task<TResult> ExecuteAsync();
}

public interface IAsyncCommand<in TData, TResult>
{
    Task<TResult> ExecuteAsync(TData data);
}