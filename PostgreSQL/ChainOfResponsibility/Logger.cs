namespace PostgreSQL.ChainOfResponsibility;

public class Logger : ILogger
{
    private readonly OutputHandler _outputHandler;

    public Logger()
    {
        _outputHandler = new ConsoleHandler();

        var debugHandler = new DebugHandler();
        _outputHandler.SetSuccessor(debugHandler);

        var fileLogHandler = new FileLogHandler();
        debugHandler.SetSuccessor(fileLogHandler);
    }

    public void Log(string message, OutputType type = OutputType.Info)
    {
        _outputHandler.HandleRequest(new Output(message, type));
    }
}