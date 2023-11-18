using Microsoft.Extensions.Logging;

namespace PostgreSQL.ChainOfResponsibility;

public interface ILogger
{
    void Log(string message, OutputType type = OutputType.Info);
}