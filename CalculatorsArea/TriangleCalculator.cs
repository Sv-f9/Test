namespace CalculatorsArea;

public class TriangleCalculator : ITriangle
{
    private const double MeasurementError = 1e-5;
    
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public TriangleCalculator(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException($"Ни один из параметров:{sideA},{sideB},{sideC} не может быть меньше 0");

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            throw new ArgumentException("Данный треугольник не может существовать");

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public bool IsRightTriangle()
    {
        double maxSide = _sideA, b = _sideB, c = _sideC;
        if (b - maxSide > 0)
            (b, maxSide) = (maxSide, b);

        if (c - maxSide > 0)
            (c, maxSide) = (maxSide, c);

        return Math.Abs(Math.Pow(maxSide, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) <= MeasurementError;
    }
    
    public double CalculateArea()
    {
        var halfPerimeter = (_sideA + _sideB + _sideC) / 2;
        var area = Math.Sqrt(halfPerimeter
                             * (halfPerimeter - _sideA)
                             * (halfPerimeter - _sideB)
                             * (halfPerimeter - _sideC)
        );

        return area;
    }
}