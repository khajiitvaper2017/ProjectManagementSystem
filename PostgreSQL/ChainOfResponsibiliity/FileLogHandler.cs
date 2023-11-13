namespace PostgreSQL.ChainOfResponsibiliity;

public sealed class FileLogHandler : OutputHandler
{
    public override void HandleRequest(Output output)
    {
        if (output.Type >= OutputType.Info)
        {
            File.AppendAllText("log.txt", $"{DateTime.Today} | {output.Type}: {output.Message}");
        }

        if (Successor != null)
        {
            Successor.HandleRequest(output);
        }
    }
}
