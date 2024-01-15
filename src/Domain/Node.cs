namespace Domain;

public class Node
{
    public Node? Left { get; set; }
    private string? _value;
    public Node? Right { get; set; }

    public Node() { }
    public Node(string value) : this() => _value = value;

    public double Evaluate()
    {
        if (IsEmpty())
            return 0;

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

    private bool IsEmpty()
    {
        return string.IsNullOrEmpty(_value);
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