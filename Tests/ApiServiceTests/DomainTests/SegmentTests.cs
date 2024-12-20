using ApiService.Domain;

namespace Tests.ApiServiceTests.DomainTests;

public class SegmentTests
{
    [Fact]
    public void Contains_PointOnSegment_ReturnsTrue()
    {
        var start = new Point(0, 0);
        var end = new Point(4, 4);
        var segment = new Segment(start, end);
        var pointOnSegment = new Point(2, 2);

        var result = segment.Contains(pointOnSegment);

        Assert.True(result);
    }

    [Fact]
    public void Contains_PointAtStart_ReturnsTrue()
    {
        var start = new Point(0, 0);
        var end = new Point(4, 4);
        var segment = new Segment(start, end);
        var pointAtStart = new Point(0, 0);

        var result = segment.Contains(pointAtStart);

        Assert.True(result);
    }

    [Fact]
    public void Contains_PointAtEnd_ReturnsTrue()
    {
        var start = new Point(0, 0);
        var end = new Point(4, 4);
        var segment = new Segment(start, end);
        var pointAtEnd = new Point(4, 4);

        var result = segment.Contains(pointAtEnd);

        Assert.True(result);
    }

    [Fact]
    public void Contains_PointOutsideSegment_ReturnsFalse()
    {
        var start = new Point(0, 0);
        var end = new Point(4, 4);
        var segment = new Segment(start, end);
        var pointOutsideSegment = new Point(5, 5);

        var result = segment.Contains(pointOutsideSegment);

        Assert.False(result);
    }

    [Fact]
    public void Contains_PointOnLineButOutsideSegment_ReturnsFalse()
    {
        var start = new Point(0, 0);
        var end = new Point(4, 4);
        var segment = new Segment(start, end);
        var pointOnLineButOutsideSegment = new Point(-1, -1);

        var result = segment.Contains(pointOnLineButOutsideSegment);

        Assert.False(result);
    }

    [Fact]
    public void Contains_PointOnHorizontalSegment_ReturnsTrue()
    {
        var start = new Point(0, 3);
        var end = new Point(5, 3);
        var segment = new Segment(start, end);
        var pointOnSegment = new Point(3, 3);

        var result = segment.Contains(pointOnSegment);

        Assert.True(result);
    }

    [Fact]
    public void Contains_PointNotOnLine_ReturnsFalse()
    {
        var start = new Point(0, 0);
        var end = new Point(4, 4);
        var segment = new Segment(start, end);
        var pointNotOnLine = new Point(1, 0);

        var result = segment.Contains(pointNotOnLine);

        Assert.False(result);
    }
}
