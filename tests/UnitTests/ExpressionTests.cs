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
    
    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("10", 10)]
    [InlineData("100", 100)]
    public void Model_ExpressionWithNumber_ReturnsNumber(string numberAsString, double expectedOutput)
    {
        // arrange
        var expression = new Expression(numberAsString);

        // act
        var root = expression.Model();
        var result = root.Evaluate();

        // assert
        result.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("+")]
    [InlineData("-")]
    [InlineData("*")]
    [InlineData("/")]
    public void Model_ExpressionWithOperator_Returns0(string operatorAsString)
    {
        // arrange
        var expression = new Expression(operatorAsString);

        // act
        var root = expression.Model();
        var result = root.Evaluate();

        // assert
        result.Should().Be(0);
    }
}