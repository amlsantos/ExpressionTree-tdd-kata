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

    private bool IsNumber()
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
        return IsNumber() && double.Parse(Value) == 0;
    }
}

// public class OperationNode : Node
// {
//     public OperationNode(string value, Node left, Node? right) : base(value, left, right) { }
//
//     public override double Evaluate()
//     {
//         switch (_value)
//         {
//             case "+":
//                 return Sum();
//             case "-":
//                 return Subtraction();
//             case "*":
//                 return Multiplication();
//             case "/":
//                 return Division();
//
//             default:
//                 return 0;
//         }
//     }
// }