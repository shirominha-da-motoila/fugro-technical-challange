using System.Diagnostics.CodeAnalysis;
using Domain.Utils;

namespace Domain;

public class Segment
{
    [SetsRequiredMembers]
    public Segment(Point start, Point end)
    {
        if (start.Equals(end))
        {
            throw new InvalidOperationException("Segment points can't be equal");
        }

        this.Start = start;
        this.End = end;
        this.Line = new Line(this);
    }

    public required Point Start { get; init; }

    public required Point End { get; init; }

    public required Line Line { get; init; }

    public double YVar => this.End.Y - this.Start.Y;

    public double XVar => this.End.X - this.Start.X;

    public bool Contains(Point point)
    {
        if (!this.Line.Contains(point))
        {
            return false;
        }

        return point.X.IsBetween(Start.X, End.X) && point.Y.IsBetween(Start.Y, End.Y);
    }
}