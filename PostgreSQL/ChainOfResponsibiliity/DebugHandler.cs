using System.Diagnostics;

namespace PostgreSQL.ChainOfResponsibiliity;

public sealed class DebugHandler : OutputHandler
{
    public override void HandleRequest(Output output)
    {
        if (output.Type >= OutputType.Debug)
        {
            Debug.WriteLine(output.Message);
        }

        if (Successor != null)
        {
            Successor.HandleRequest(output);
        }
    }
}
