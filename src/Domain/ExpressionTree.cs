namespace Domain;

public class ExpressionTree
{
    private readonly string _expression;
    public ExpressionTree(string expression) => _expression = expression;

    public Node Model()
    {
        if (string.IsNullOrEmpty(_expression))
            return new Node();
        
        var space = " ";
        var expressionValues = _expression.Split(space);
        if (expressionValues.Length == 1)
            return new Node(expressionValues[0]);
        
        // valid expression = 3 values
        if (!IsValid(expressionValues))
            throw new InvalidOperationException();

        return BuildSimpleTree(expressionValues);
    }

    private bool IsValid(string[] expression) => expression.Length >= 3;

    private static Node BuildSimpleTree(IReadOnlyList<string> values)
    {
        var root = new Node(values[1]);
        
        var left = new Node(values[0]);
        root.Left = left;

        var right = new Node(values[2]);
        root.Right = right;

        return root;
    }
}