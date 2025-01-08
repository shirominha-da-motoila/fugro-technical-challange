using System.Diagnostics.CodeAnalysis;

namespace ApiService.Domain;

[method: SetsRequiredMembers]
public class Polyline(IEnumerable<Point> values)
{
    public required LinkedList<Point> Points { get; init; } = new LinkedList<Point>
    (
        values.Select((value) => new Point(value.X, value.Y))
    );

    public IEnumerable<(double, double)> CalculateOffsetsAndStations(Point point)
    {
        var (currentNode, nextNode) = GetFirstAndSecondNode();
        double? offset = null;
        double segmentsLength = 0;
        List<(double, double)>? output = null;

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
                offset = possibleOffset;
                output = [(offset.Value, segmentsLength - currentNode.Value.DistanceToPoint(possibleIntersection))];

                continue;
            }

            if (output is not null && possibleOffset == offset)
            {
                offset = possibleOffset;
                output.Add((offset.Value, segmentsLength - currentNode.Value.DistanceToPoint(possibleIntersection)));
            }
        }

        if (output is null)
        {
            throw new InvalidPolylineException();
        }

        return output.ToHashSet();
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