using Domain.Nodes;

namespace Domain;

public class ExpressionTree
{
    private readonly string _expression;
    public ExpressionTree(string expression) => _expression = expression;

    public Node Model()
    {
        if (string.IsNullOrEmpty(_expression))
            return Node.Create("");
        
        var space = " ";
        var expressionValues = _expression.Split(space);
        if (expressionValues.Length == 1)
            return Node.Create(expressionValues[0]);
        
        // valid expression = 3 values
        if (!IsValid(expressionValues))
            throw new InvalidOperationException();

        return BuildSimpleTree(expressionValues);
    }

    private bool IsValid(string[] expression) => expression.Length >= 3;

    private static Node BuildSimpleTree(IReadOnlyList<string> values)
    {
        var left = Node.Create(values[0]);
        var right = Node.Create(values[2]);
        
        var root = Node.Create(values[1], left, right);

        return root;
    }
}