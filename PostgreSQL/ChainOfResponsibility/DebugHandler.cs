using System.Diagnostics;

namespace PostgreSQL.ChainOfResponsibility;

public sealed class DebugHandler : OutputHandler
{
    public override void HandleRequest(Output output)
    {
        if (output.Type >= OutputType.Debug)
        {
            Debug.WriteLine(output.Message);
        }

        Successor?.HandleRequest(output);
    }
}
