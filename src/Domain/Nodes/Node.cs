namespace Domain.Nodes;

public class Node
{
    protected readonly string? Value;
    protected readonly Node? _left;
    protected readonly Node? _right;

    protected Node() { }
    protected Node(string value) => Value = value;
    protected Node(string value, Node left, Node right) : this()
    {
        Value = value;
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

        return new OperationNode(value, left, right);
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
        return 0;
    }
    
    protected internal bool IsZero() => IsNumber() && double.Parse(Value) == 0;

    protected bool IsNumber()
    {
        switch (Value)
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
}