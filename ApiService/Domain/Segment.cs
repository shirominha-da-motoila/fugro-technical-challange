using System.Diagnostics.CodeAnalysis;
using ApiService.Domain.Utils;

namespace ApiService.Domain;

public class Segment
{
    [SetsRequiredMembers]
    public Segment(Point start, Point end)
    {
        if (start.Equals(end))
        {
            throw new InvalidOperationException("Segment points can't be equal");
        }

        Start = start;
        End = end;
        Line = new Line(this);
    }

    public required Point Start { get; init; }

    public required Point End { get; init; }

    public required Line Line { get; init; }

    public double YVar => End.Y - Start.Y;

    public double XVar => End.X - Start.X;

    public bool Contains(Point point)
    {
        if (!Line.Contains(point))
        {
            return false;
        }

        return point.X.IsBetween(Start.X, End.X) && point.Y.IsBetween(Start.Y, End.Y);
    }
}