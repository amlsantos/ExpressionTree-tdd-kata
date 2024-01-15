namespace Domain;

public class Node
{
    private char? _value;

    public Node() { }
    public Node(char value) : this() => _value = value;

    public double Evaluate()
    {
        if (IsEmpty())
            return 0;
            
        // convert char to number
        return double.Parse(_value.Value.ToString());
        
        return (double)_value.Value;
    }

    private bool IsEmpty()
    {
        return !_value.HasValue;
    }
}