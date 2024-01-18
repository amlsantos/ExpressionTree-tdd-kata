namespace Domain.Nodes;

public class OperationNode : Node
{
    private readonly string? _operator;
    private readonly Node? _left;
    private readonly Node? _right;
    public OperationNode(string _operator, Node left, Node right)
    {
        this._operator = _operator;
        _left = left;
        _right = right;
    }

    public override double Evaluate()
    {
        switch (_operator)
        {
            case "+":
                return Sum();
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
    
    private double Sum() => _left.Evaluate() + _right.Evaluate();
    private double Subtraction() => _left.Evaluate() - _right.Evaluate();
    private double Multiplication() => _left.Evaluate() * _right.Evaluate();
    private double Division()
    {
        if (_left.Evaluate() == 0)
            throw new InvalidOperationException();
        if (_right.Evaluate() == 0)
            throw new InvalidOperationException();

        return _left.Evaluate() / _right.Evaluate();
    }
}