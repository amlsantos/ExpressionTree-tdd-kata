namespace Domain;

public class Node
{
    public Node? Left { get; set; }
    private string? _value;
    public Node? Right { get; set; }

    protected Node() { }
    protected Node(string value) : this() => _value = value;

    public static Node Create(string value)
    {
        if (IsEmpty(value))
            return new EmptyNode();
        
        return new Node(value);
    }

    private static bool IsEmpty(string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public virtual double Evaluate()
    {
        
        if (IsLeaf() && !IsNumber())
            return 0;

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

public class EmptyNode : Node
{
    public EmptyNode() { }

    public override double Evaluate()
    {
        return 0;
    }
}