using FluentAssertions;
using Xunit;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void Model_EmptyExpression_Returns0()
    {
        // arrange
        var emptyExpression = string.Empty;
        var expression = new Expression();

        // act
        var root = expression.Model();
        var result = root.Evaluate();

        // assert
        result.Should().Be(0);
    }
}

public class Expression
{
    public Node Model()
    {
        var node = new Node();
        return node;
    }
}

public class Node
{
    public double Evaluate()
    {
        return 0;
    }
}