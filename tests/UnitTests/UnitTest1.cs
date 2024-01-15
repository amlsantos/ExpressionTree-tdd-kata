using FluentAssertions;
using Xunit;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void Model_EmptyExpression_Returns0()
    {
        // arrange
        var empty = string.Empty;
        var expression = new Expression(empty);

        // act
        var root = expression.Model();
        var result = root.Evaluate();

        // assert
        result.Should().Be(0);
    }
}

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

public class Node
{
    private char? _value;

    public Node() { }
    public Node(char value) : this() => _value = value;

    public double Evaluate()
    {
        return 0;
    }
}