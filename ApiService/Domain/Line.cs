using System.Diagnostics.CodeAnalysis;

namespace ApiService.Domain;

/// <summary>
/// Properties A, B and C are the coeficients of the line equation of the form: ax + by + c = 0
/// </summary>
public class Line
{
    [SetsRequiredMembers]
    public Line(Segment segment)
    {
        // This condition is impossible due to Segment checks.
        // But this ensures no Line is instantiated with impossible parameters.
        if (segment.YVar == 0 && segment.XVar == 0)
        {
            throw new ArgumentException("A and B cannot be 0.");
        }

        A = -segment.YVar;
        B = segment.XVar;
        var end = segment.End;
        C = -A * end.X - B * end.Y;
    }

    [SetsRequiredMembers]
    public Line(double a, double b, double c)
    {
        if (a == 0 && b == 0)
        {
            throw new ArgumentException("A and B cannot be 0.");
        }

        A = a;
        B = b;
        C = c;
    }

    public required double A { get; init; }

    public required double B { get; init; }

    public required double C { get; init; }

    public double DistanceToPoint(Point point)
    {

        var numerator = Math.Abs(A * point.X + B * point.Y + C);
        var denominator = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));

        return numerator / denominator;
    }

    public Line GetPerpendicularLine(Point point)
    {
        // Linw Form: by + c = 0 => y = - c/b
        if (A == 0)
        {
            // Perpendicular Line Form: x = k => x - k = 0
            return new Line(1, 0, -point.X);
        }

        // Form: y = mx + q => -mx + y - q = 0
        var slope = B / A;
        var q = point.Y - slope * point.X;

        return new Line(-slope, 1, -q);
    }

    public Point GetIntersection(Line line)
    {
        var xNumerator = B * line.C - line.B * C;
        var xDenominator = A * line.B - line.A * B;

        if (xDenominator == 0)
        {
            throw new InvalidOperationException("Lines are parallel and don't intersect.");
        }

        var x = xNumerator / xDenominator;

        var yNumerator = - C - A * x;
        var yDenominator = B;

        if (yDenominator == 0)
        {
            var y2 = (line.A * x + line.C) / (- line.B);

            return new Point(x, y2);
        }

        var y = yNumerator / yDenominator;

        return new Point(x, y);
    }

    public bool Contains(Point point)
    {
        return A * point.X + B * point.Y + C == 0;
    }
}