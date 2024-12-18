namespace ApiService.Domain;

class Polyline(ICollection<(double, double)> values)
{
    public required LinkedList<Point> Points { get; init; } = new LinkedList<Point>(values.Select((value) => new Point(value.Item1, value.Item2)));
}