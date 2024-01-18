namespace Domain.Nodes;

public abstract class Node
{
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

    public abstract double Evaluate();
}