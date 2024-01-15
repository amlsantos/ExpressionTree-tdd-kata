namespace Domain;

public class Node
{
    public Node Left { get; set; }
    private string? _value;
    public Node Right { get; set; }

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
                return Left.Evaluate() + Right.Evaluate();
            case "-":
                return Left.Evaluate() - Right.Evaluate();
            case "*":
                return Left.Evaluate() * Right.Evaluate();
            case "/":
            {
                if (Left.IsZero() || Right.IsZero())
                    throw new InvalidOperationException();
                
                return Left.Evaluate() / Right.Evaluate();
            }
                
            default:
                return 0;
        }
    }

    private bool IsZero()
    {
        return IsNumber() && double.Parse(_value) == 0;
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

    private bool IsEmpty()
    {
        return string.IsNullOrEmpty(_value);
    }
}