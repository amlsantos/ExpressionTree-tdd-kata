namespace Domain.Nodes;

public class Node
{
    private Node? Left { get; }
    private readonly string? _value;
    private Node? Right { get; }

    protected Node() { }
    protected Node(string value, Node left, Node right) : this()
    {
        _value = value;
        Left = left;
        Right = right;
    }

    public static Node Create(string value, Node? left = null, Node? right = null)
    {
        if (IsEmpty(value))
            return new EmptyNode();
        if (IsLeaf(left, right) && !IsNumber(value))
            return new LeafNode();
        
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
        if (IsNumber())
            return double.Parse(_value);

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

    private bool IsLeaf() => (Left is null && Right is null);

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
        return Left.Evaluate() + Right.Evaluate();
    }

    private double Subtraction()
    {
        return Left.Evaluate() - Right.Evaluate();
    }

    private double Multiplication()
    {
        return Left.Evaluate() * Right.Evaluate();
    }

    private double Division()
    {
        if (Left.IsZero() || Right.IsZero())
            throw new InvalidOperationException();

        return Left.Evaluate() / Right.Evaluate();
    }

    private bool IsZero()
    {
        return IsNumber() && double.Parse(_value) == 0;
    }
}