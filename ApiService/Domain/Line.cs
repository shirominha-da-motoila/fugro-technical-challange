using System.Diagnostics.CodeAnalysis;

namespace ApiService.Domain;

[method: SetsRequiredMembers]
public class Line(Segment segment)
{
    public required double A { get; init; } = -segment.YVar;

    public required double B { get; init; } = segment.XVar;

    public required double C { get; init; } = segment.YVar * segment.Start.X - segment.XVar * segment.Start.Y;

    public double DistanceToPoint(Point point)
    {

        var numerator = Math.Abs(A * point.X + B * point.Y + C);
        var denominator = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));

        return numerator / denominator;
    }

    public bool Contains(Point point)
    {
        return A * point.X + B * point.Y + C == 0;
    }
}