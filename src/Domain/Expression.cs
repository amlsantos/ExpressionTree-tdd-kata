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
        if (values.Length == 1)
        {
            var value = values[0];
            return new Node(value);
        }
        
        // valid expression = 3 values
        if (!IsValid(values))
            throw new InvalidOperationException();

        var left = new Node(values[0]);
        var root = new Node(values[1]);
        var right = new Node(values[2]);

        root.Left = left;
        root.Right = right;

        return root;
    }

    private bool IsValid(string[] expression) => expression.Length >= 3;
}