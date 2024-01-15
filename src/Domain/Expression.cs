namespace Domain;

public class Expression
{
    private readonly string _expression;
    public Expression(string expression) => _expression = expression;

    public Node Model()
    {
        if (string.IsNullOrEmpty(_expression))
            return new Node();

        // do something with expression
        var rootNode = new Node();
        return rootNode;
    }
}