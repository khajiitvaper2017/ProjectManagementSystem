namespace PostgreSQL.Commands.Core;

public interface INoResponseAsyncCommand<in TData>
{
    System.Threading.Tasks.Task ExecuteAsync(TData data);
}