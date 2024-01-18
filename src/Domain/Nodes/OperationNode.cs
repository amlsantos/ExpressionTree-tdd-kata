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
            {
                return new AdditionNode(_operator, Left, Right).Evaluate();
            }
            case "-":
                return Subtraction();
            case "*":
                return Multiplication();
            case "/":
                return Division();

            default:
                return 0;
        }
    }
    
    private double Sum() => Left.Evaluate() + Right.Evaluate();
    private double Subtraction() => Left.Evaluate() - Right.Evaluate();
    private double Multiplication() => Left.Evaluate() * Right.Evaluate();
    private double Division()
    {
        if (Left.Evaluate() == 0)
            throw new InvalidOperationException();
        if (Right.Evaluate() == 0)
            throw new InvalidOperationException();

        return Left.Evaluate() / Right.Evaluate();
    }
}