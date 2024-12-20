using ApiService.Domain;

namespace Tests.ApiServiceTests.DomainTests;

public class LineTests
{
    [Fact]
    public void DistanceToPoint_ReturnsExpectedValue_WhenLineIsGivenWithPoints()
    {
        var line = new Line(3, 4, 1);
        var point = new Point(5, 4);

        var result = line.DistanceToPoint(point);

        Assert.Equal(6.4, result);
    }

    [Fact]
    public void DistanceToPoint_ReturnsExpectedValue_WhenLineIsGivenWithPoints_SecondTest()
    {
        var line = new Line(0, 2, -4);
        var point = new Point(0, 2);

        var result = line.DistanceToPoint(point);

        Assert.Equal(0, result);
    }

    [Fact]
    public void DistanceToPoint_ReturnsExpectedValue_WhenLineIsGivenWithPoints_ThirdTest()
    {
        var line = new Line(1, 0, -3);
        var point = new Point(0, 3);

        var result = line.DistanceToPoint(point);

        Assert.Equal(3, result);
    }

    [Fact]
    public void GetPerpendicularLine_GivenNonHorizontalLine_ReturnsPerpendicularLine()
    {
        var line = new Line(-2, 1, -3);
        var point = new Point(1, 2);

        var perpendicular = line.GetPerpendicularLine(point);


        Assert.Equal(0.5, perpendicular.A);
        Assert.Equal(1, perpendicular.B);
        Assert.Equal(-2.5, perpendicular.C);
    }

    [Fact]
    public void GetPerpendicularLine_GivenHorizontalLine_ReturnsVerticalLine()
    {
        var line = new Line(0, 1, -3);
        var point = new Point(5, 3);

        var perpendicular = line.GetPerpendicularLine(point);

        Assert.Equal(1, perpendicular.A);
        Assert.Equal(0, perpendicular.B);
        Assert.Equal(-5, perpendicular.C);
    }

    [Fact]
    public void GetIntersection_GivenTwoIntersectingLines_ReturnsIntersectionPoint()
    {
        var line1 = new Line(-1, 1, -1);
        var line2 = new Line(1, 1, -3);

        var intersection = line1.GetIntersection(line2);

        Assert.Equal(1, intersection.X);
        Assert.Equal(2, intersection.Y);
    }

    [Fact]
    public void GetIntersection_GivenParallelLines_ThrowsException()
    {
        var line1 = new Line(2, -1, -1);
        var line2 = new Line(2, -1, 2);

        Assert.Throws<InvalidOperationException>(() => line1.GetIntersection(line2));
    }

    [Fact]
    public void Contains_GivenPointOnLine_ReturnsTrue()
    {
        var line = new Line(-2, 1, 1);
        var point = new Point(1, 1);

        var result = line.Contains(point);

        Assert.True(result);
    }

    [Fact]
    public void Contains_GivenPointNotOnLine_ReturnsFalse()
    {
        var line = new Line(-2, 1, 1);
        var point = new Point(0, 0); 

        var result = line.Contains(point);

        Assert.False(result);
    }

    [Fact]
    public void InvalidParametersInstantiation_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Line(0, 0, 1));
    }
}
