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
            throw new ArgumentException("Segment Points should be different.");
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

    public double Length => Math.Sqrt(Math.Pow(XVar, 2) +  Math.Pow(YVar, 2));

    public bool Contains(Point point)
    {
        if (!Line.Contains(point))
        {
            return false;
        }

        return point.X.IsBetween(Start.X, End.X) && point.Y.IsBetween(Start.Y, End.Y);
    }
}