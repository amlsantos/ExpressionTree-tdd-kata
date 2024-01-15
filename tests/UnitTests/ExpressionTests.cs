using Domain;
using FluentAssertions;
using Xunit;

namespace UnitTests;

public class ExpressionTests
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
    
    [Fact]
    public void Model_ExpressionWithNumber_ReturnsNumber()
    {
        // arrange
        var numberAsString = "1";
        var expression = new Expression(numberAsString);

        // act
        var root = expression.Model();
        var result = root.Evaluate();

        // assert
        result.Should().Be(1);
    }
}