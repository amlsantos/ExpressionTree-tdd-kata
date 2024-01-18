namespace Domain.Nodes;

public class OperationNode : Node
{
    private readonly string? _operator;
    protected readonly Node? Left;
    protected readonly Node? Right;
    public OperationNode(string _operator, Node left, Node right)
    {
        this._operator = _operator;
        Left = left;
        Right = right;
    }

    public override double Evaluate()
    {
        var operation = OperationFactory.Create(_operator, Left, Right);
        return operation.Evaluate();
    }
}