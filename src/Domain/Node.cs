namespace Domain;

public class Node
{
    private string? _value;

    public Node() { }
    public Node(string value) : this() => _value = value;

    public double Evaluate()
    {
        if (IsEmpty())
            return 0;

        if (IsOperator())
            return 0;
        
        // convert char to number
        return double.Parse(_value);
    }

    private bool IsOperator()
    {
        switch (_value)
        {
            case "+":
            case "-":
            case "*":
            case "/":
                return true;
            default:
                return false;
        }
    }

    private bool IsEmpty()
    {
        return string.IsNullOrEmpty(_value);
    }
}