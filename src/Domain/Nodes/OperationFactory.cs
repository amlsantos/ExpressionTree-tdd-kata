namespace Domain.Nodes;

public static class OperationFactory
{
    public static OperationNode Create(string _operator, Node left, Node right)
    {
        return _operator switch
        {
            "+" => new AdditionNode(_operator, left, right),
            "-" => new SubtractionNode(_operator, left, right),
            "*" => new MultiplicationNode(_operator, left, right),
            "/" => new DivisionNode(_operator, left, right),
            _ => throw new InvalidOperationException()
        };
    }
}