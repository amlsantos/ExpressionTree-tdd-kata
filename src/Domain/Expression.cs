namespace Domain;

public class Expression
{
    private readonly string _expression;
    public Expression(string expression) => _expression = expression;

    public Node Model()
    {
        if (string.IsNullOrEmpty(_expression))
            return new Node();

        var value = _expression[0];
        return new Node(value);
    }
}