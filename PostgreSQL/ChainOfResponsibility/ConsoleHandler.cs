namespace PostgreSQL.ChainOfResponsibility;

public sealed class ConsoleHandler : OutputHandler
{
    public override void HandleRequest(Output output)
    {
        if (output.Type >= OutputType.Warning)
        {
            Console.WriteLine(output.Message);
        }

        Successor?.HandleRequest(output);
    }
}
