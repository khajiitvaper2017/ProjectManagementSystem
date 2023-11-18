namespace PostgreSQL.ChainOfResponsibility;
public abstract class OutputHandler
{
    protected OutputHandler? Successor;

    public void SetSuccessor(OutputHandler successor)
    {
        Successor = successor;
    }

    public abstract void HandleRequest(Output output);
}