using ApiService.Domain;

namespace Tests.ApiServiceTests.DomainTests;
public class PolylineTests
{
    [Fact]
    public void GetFirstAndSecondNode_ReturnsCorrectNodes_WhenTwoPointsInList()
    {
        var polyline = CreatePolyline([(0, 0), (3, 4)]);

        var (firstNode, secondNode) = polyline.GetFirstAndSecondNode();

        Assert.Equal(0, firstNode.Value.X);
        Assert.Equal(0, firstNode.Value.Y);
        Assert.Equal(3, secondNode.Value.X);
        Assert.Equal(4, secondNode.Value.Y);
    }

    [Fact]
    public void GetFirstAndSecondNode_ThrowsException_WhenOnlyOnePointInList()
    {
        var polyline = CreatePolyline([(0, 0)]);

        Assert.Throws<Polyline.InvalidPolylineException>(() => polyline.GetFirstAndSecondNode());
    }

    [Fact]
    public void GetFirstAndSecondNode_ThrowsException_WhenNoPointsInList()
    {
        var polyline = CreatePolyline([]);

        Assert.Throws<Polyline.InvalidPolylineException>(() => polyline.GetFirstAndSecondNode());
    }

    [Fact]
    public void CalculateOffsetAndStation_ReturnsCorrectOffsetAndStation_WhenPointIsOnSegment()
    {
        var polyline = CreatePolyline([(0, 0), (3, 4), (6, 8)]);
        var point = new Point(3, 4);

        var output = polyline.CalculateOffsetsAndStations(point);

        var (offset, station) = Assert.Single(output);
        Assert.Equal(0, offset); 
        Assert.Equal(5, station);
    }

    [Fact]
    public void CalculateOffsetAndStation_ThrowsException_WhenPointIsOutsidePolyline()
    {
        var polyline = CreatePolyline([(0, 0), (3, 4)]);
        var point = new Point(5, 5);

        Assert.Throws<Polyline.InvalidPolylineException>(() => polyline.CalculateOffsetsAndStations(point));
    }

    [Fact]
    public void CalculateOffsetAndStation_ReturnsCorrectOffsetAndStation_ForPointOnFirstSegment()
    {
        var polyline = CreatePolyline([(0, 0), (3, 4), (6, 8)]);
        var point = new Point(1.5, 2);

        var output = polyline.CalculateOffsetsAndStations(point);

        var (offset, station) = Assert.Single(output);
        Assert.Equal(0, offset);
        Assert.Equal(2.5, station);
    }

    [Fact]
    public void CalculateOffsetAndStation_ReturnsCorrectOffsetAndStation_ForPointOnLastSegment()
    {
        var polyline = CreatePolyline([(0, 0), (3, 4), (6, 8)]);
        var point = new Point(6, 8);

        var output = polyline.CalculateOffsetsAndStations(point);

        var (offset, station) = Assert.Single(output);
        Assert.Equal(0, offset);
        Assert.Equal(10, station);
    }

    private static Polyline CreatePolyline(IEnumerable<(double, double)> points)
    {
        return new Polyline(points.Select(p => new Point(p.Item1, p.Item2)));
    }
}
