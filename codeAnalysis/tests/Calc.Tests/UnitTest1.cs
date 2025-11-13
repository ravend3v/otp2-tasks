using CodeAnalysis;

namespace Calc.Tests;

public class CalculatorTests
{
    [Fact]
    public void MultiplyNumbers_WithPositiveNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = 5;
        int num2 = 3;
        int expected = 15;

        // Act
        int result = Program.MultiplyNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MultiplyNumbers_WithNegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = -4;
        int num2 = 6;
        int expected = -24;

        // Act
        int result = Program.MultiplyNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MultiplyNumbers_WithZero_ReturnsZero()
    {
        // Arrange
        int num1 = 0;
        int num2 = 10;
        int expected = 0;

        // Act
        int result = Program.MultiplyNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SumNumbers_WithPositiveNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = 7;
        int num2 = 3;
        int expected = 10;

        // Act
        int result = Program.SumNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SumNumbers_WithNegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = -5;
        int num2 = -3;
        int expected = -8;

        // Act
        int result = Program.SumNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SumNumbers_WithMixedSigns_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = 10;
        int num2 = -4;
        int expected = 6;

        // Act
        int result = Program.SumNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DivideNumbers_WithValidNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = 15;
        int num2 = 3;
        double expected = 5.0;

        // Act
        double result = Program.DivideNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result, precision: 2);
    }

    [Fact]
    public void DivideNumbers_WithDecimalResult_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = 10;
        int num2 = 3;
        double expected = 3.333333333333333;

        // Act
        double result = Program.DivideNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result, precision: 10);
    }

    [Fact]
    public void DivideNumbers_WithZeroDivisor_ThrowsDivideByZeroException()
    {
        // Arrange
        int num1 = 10;
        int num2 = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => Program.DivideNumbers(num1, num2));
    }

    [Fact]
    public void DivideNumbers_WithNegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int num1 = -12;
        int num2 = 4;
        double expected = -3.0;

        // Act
        double result = Program.DivideNumbers(num1, num2);

        // Assert
        Assert.Equal(expected, result, precision: 2);
    }
}