namespace Domain.Nodes;

public class Node
{
    private readonly string? _value;
    private readonly Node? _left;
    private readonly Node? _right;

    protected Node() { }
    protected Node(string value) => _value = value;
    protected Node(string value, Node left, Node right) : this()
    {
        _value = value;
        _left = left;
        _right = right;
    }

    public static Node Create(string value, Node? left = null, Node? right = null)
    {
        if (IsEmpty(value))
            return new EmptyNode();
        if (IsLeaf(left, right) && !IsNumber(value))
            return new LeafNode();
        if (IsNumber(value))
            return new ValueNode(value);
        
        return new Node(value, left, right);
    }

    private static bool IsEmpty(string input) => string.IsNullOrEmpty(input);

    private static bool IsLeaf(Node? left, Node? right) => left is null && right is null;

    private static bool IsNumber(string input)
    {
        switch (input)
        {
            case "+":
            case "-":
            case "*":
            case "/":
                return false;
            default:
                return true;
        }
    }

    public virtual double Evaluate()
    {
        switch (_value)
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

    private bool IsNumber()
    {
        switch (_value)
        {
            case "+":
            case "-":
            case "*":
            case "/":
                return false;
            default:
                return true;
        }
    }

    private double Sum()
    {
        return _left.Evaluate() + _right.Evaluate();
    }

    private double Subtraction()
    {
        return _left.Evaluate() - _right.Evaluate();
    }

    private double Multiplication()
    {
        return _left.Evaluate() * _right.Evaluate();
    }

    private double Division()
    {
        if (_left.IsZero() || _right.IsZero())
            throw new InvalidOperationException();

        return _left.Evaluate() / _right.Evaluate();
    }

    private bool IsZero()
    {
        return IsNumber() && double.Parse(_value) == 0;
    }
}