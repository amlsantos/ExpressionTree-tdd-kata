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
        switch (_operator)
        {
            case "+":
                return new AdditionNode(_operator, Left, Right).Evaluate();
            case "-":
                return new SubtractionNode(_operator, Left, Right).Evaluate();
            case "*":
                return new MultiplicationNode(_operator, Left, Right).Evaluate();
            case "/":
                return new DivisionNode(_operator, Left, Right).Evaluate();

            default:
                return 0;
        }
    }
}