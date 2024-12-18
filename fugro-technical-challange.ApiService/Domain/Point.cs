using System.Diagnostics.CodeAnalysis;

namespace Domain;

[method:SetsRequiredMembers]
public class Point(double x, double y) : IEquatable<Point>
{
    public required double X { get; init; } = x;

    public required double Y { get; init; } = y;

    public bool Equals(Point? other)
    {
        return other is not null && this.X == other.X && this.Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point point && Equals(point);
    }

    public override int GetHashCode()
    {
        return this.X.GetHashCode() + this.Y.GetHashCode();
    }
}