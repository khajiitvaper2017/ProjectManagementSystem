
namespace PostgreSQL.CQRS.Core.Command;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command);
}