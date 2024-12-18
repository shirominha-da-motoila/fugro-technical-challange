using System.Diagnostics.CodeAnalysis;

namespace Domain;

[method: SetsRequiredMembers]
public class Line(Segment segment)
{
    public required double A { get; init; } = -segment.YVar;

    public required double B { get; init; } = segment.XVar;

    public required double C { get; init; } = segment.YVar * segment.Start.X - segment.XVar * segment.Start.Y;

    public double DistanceToPoint(Point point)
    {

        var numerator = Math.Abs(this.A * point.X + this.B * point.Y + this.C);
        var denominator = Math.Sqrt(Math.Pow(this.A, 2) + Math.Pow(this.B, 2));

        return numerator/denominator;
    }

    public bool Contains(Point point)
    {
        return this.A * point.X + this.B * point.Y + this.C == 0;
    }
}