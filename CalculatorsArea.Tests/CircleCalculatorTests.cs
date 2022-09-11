using Xunit;

namespace CalculatorsArea.Tests;

public class CalculatorFiguresTests
{
    private const double MeasurementError = 1e-5;
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(-130)]
    public void Should_ThrowException_ForInvalidRadius(double radius)
    {
        //Assert
        Assert.Throws<ArgumentException>(() => new CircleCalculator(radius));
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(500)]
    [InlineData(500000)]
    public void Should_CalculateArea(double radius)
    {
        //Arrange
        ICalculator circleCalculator = new CircleCalculator(radius);
        double exceptedArea = Math.PI * Math.Pow(radius, 2);
        
        //Act
        double circleArea = circleCalculator.CalculateArea();
        
        //Assert
        Assert.InRange(Math.Abs(circleArea-exceptedArea), 0, MeasurementError);
    }
}