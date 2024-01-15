namespace Domain;

public class Expression
{
    private readonly string _expression;
    public Expression(string expression) => _expression = expression;

    public Node Model()
    {
        if (string.IsNullOrEmpty(_expression))
            return new Node();

        var space = " ";
        var values = _expression.Split(space);
        
        var value = values[0];
        return new Node(value);
    }
}