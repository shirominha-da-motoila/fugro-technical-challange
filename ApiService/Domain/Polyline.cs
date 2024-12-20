using System.Diagnostics.CodeAnalysis;

namespace ApiService.Domain;

[method: SetsRequiredMembers]
public class Polyline(IEnumerable<(double, double)> values)
{
    public required LinkedList<Point> Points { get; init; } = new LinkedList<Point>
    (
        values.Select((value) => new Point(value.Item1, value.Item2))
    );

    public (double, double) CalculateOffsetAndStation(Point point)
    {
        var (currentNode, nextNode) = GetFirstAndSecondNode();
        double? offset = null;
        double station = 0;
        double segmentsLength = 0;

        while (nextNode is not null)
        {
            var segment = new Segment(currentNode.Value, nextNode.Value);
            segmentsLength += segment.Length;
            var line = segment.Line;
            var perpendicularLine = line.GetPerpendicularLine(point);
            var possibleIntersection = line.GetIntersection(perpendicularLine);
            currentNode = nextNode;
            nextNode = nextNode.Next;

            if (!segment.Contains(possibleIntersection))
            {
                continue;
            }

            var possibleOffset = segment.Line.DistanceToPoint(point);

            if (offset is null || possibleOffset < offset)
            {
                station = segmentsLength - currentNode.Value.DistanceToPoint(point);
                offset = possibleOffset;
            }
        }

        if (offset is null)
        {
            throw new InvalidPolylineException();
        }

        return (offset.Value, station);
    }

    public (LinkedListNode<Point>, LinkedListNode<Point>) GetFirstAndSecondNode()
    {
        var currentNode = Points.First ?? throw new InvalidPolylineException();
        var nextNode = currentNode.Next ?? throw new InvalidPolylineException();

        return (currentNode, nextNode);
    }

    public class InvalidPolylineException : InvalidOperationException
    {
        public InvalidPolylineException() : base("It's not possible to calculate Offset and Station of this Polyline.")
        {
        }
    }
}