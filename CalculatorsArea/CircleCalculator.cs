namespace CalculatorsArea;

public class CircleCalculator : ICalculator
{
    private readonly double _radius;

    public CircleCalculator(double radius)
    {
        if (radius <= 0) throw new ArgumentException($"радиус:{radius} не можем быть меньше 0");

        _radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}