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

    [Theory]
    [InlineData("1 + 1", 2)]
    [InlineData("10 + 10", 20)]
    [InlineData("100 + 1000", 1100)]
    [InlineData("1 - 1", 0)]
    [InlineData("10 - 1", 9)]
    [InlineData("100 - 1000", -900)]
    [InlineData("90 * 1", 90)]
    [InlineData("10 * 1", 10)]
    [InlineData("21 * 10", 210)]
    [InlineData("90 / 1", 90)]
    [InlineData("10 / 1", 10)]
    [InlineData("21 / 10", 2.1)]
    [InlineData("50 / 10", 5)]
    [InlineData("15 / 5", 3)]
    public void Model_ExpressionWith2NumbersAndOperator_ReturnsResult(string expressionAsString, double expectedResult)
    {
        // arrange
        var expression = new Expression(expressionAsString);
        
        // act
        var root = expression.Model();
        var result = root.Evaluate();
        
        // assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("21 / 0")]
    [InlineData("0 / 0")]
    [InlineData("0 / 1")]
    public void Model_ExpressionWithInvalidDivision_ThrowsException(string invalidExpression)
    {
        // arrange
        var expression = new Expression(invalidExpression);
        
        // act
        var root = expression.Model();
        var exception = () => root.Evaluate();
        
        // assert
        exception.Should().Throw<InvalidOperationException>();
    }
}