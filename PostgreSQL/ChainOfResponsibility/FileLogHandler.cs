namespace PostgreSQL.ChainOfResponsibility;

public sealed class FileLogHandler : OutputHandler
{
    public override void HandleRequest(Output output)
    {
        if (output.Type >= OutputType.Info)
        {
            File.AppendAllText("log.txt", $"{DateTime.Today} | {output.Type}: {output.Message}\n");
        }

        if (Successor != null)
        {
            Successor.HandleRequest(output);
        }
    }
}
