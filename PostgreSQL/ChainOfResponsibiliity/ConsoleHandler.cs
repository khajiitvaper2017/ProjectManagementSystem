﻿namespace PostgreSQL.ChainOfResponsibiliity;

public sealed class ConsoleHandler : OutputHandler
{
    public override void HandleRequest(Output output)
    {
        if (output.Type >= OutputType.Warning)
        {
            Console.WriteLine(output.Message);
        }

        if (Successor != null)
        {
            Successor.HandleRequest(output);
        }
    }
}
