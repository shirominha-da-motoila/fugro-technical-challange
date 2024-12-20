using System.Diagnostics.CodeAnalysis;

namespace ApiService.Domain;

[method: SetsRequiredMembers]
public class Point(double x, double y) : IEquatable<Point>
{
    public required double X { get; init; } = x;

    public required double Y { get; init; } = y;

    public bool Equals(Point? other)
    {
        return other is not null && X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point point && Equals(point);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() * 2 + Y.GetHashCode();
    }

    public double DistanceToPoint(Point point)
    {
        var xVar = X - point.X;
        var yVar = Y - point.Y;

        return Math.Sqrt(Math.Pow(xVar, 2) + Math.Pow(yVar, 2));
    }
}