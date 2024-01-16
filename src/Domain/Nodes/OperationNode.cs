namespace Domain.Nodes;

public class OperationNode : Node
{
    public OperationNode(string value, Node left, Node right) : base(value, left, right) { }

    public override double Evaluate()
    {
        switch (Value)
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
        if (_left.IsZero() || _right.IsZero())
            throw new InvalidOperationException();

        return _left.Evaluate() / _right.Evaluate();
    }
}