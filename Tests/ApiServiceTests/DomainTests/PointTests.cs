using ApiService.Domain;

namespace Tests.ApiServiceTests.DomainTests;

public class PointTests
{
    [Fact]
    public void Equals_DifferentXValues_ReturnsFalse()
    {
        var point1 = new Point(1, 1);
        var point2 = new Point(2, 1);

        Assert.False(point1.Equals(point2));
    }

    [Fact]
    public void Equals_DifferentYValues_ReturnsFalse()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(1, 1);

        Assert.False(point1.Equals(point2));
    }
    
    [Fact]
    public void Equals_SameXAndYValues_ReturnsTrue()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(1, 2);

        Assert.True(point1.Equals(point2));
    }

    [Fact]
    public void DistanceToPoint_SamePoint_ReturnsZero()
    {
        var point1 = new Point(0, 0);
        var point2 = new Point(0, 0);

        var result = point1.DistanceToPoint(point2);

        Assert.Equal(0, result);
    }

    [Fact]
    public void DistanceToPoint_DifferentPoints_ReturnsCorrectDistance()
    {
        var point1 = new Point(0, 0);
        var point2 = new Point(3, 4);

        var result = point1.DistanceToPoint(point2);

        Assert.Equal(5, result, 1);
    }

    [Fact]
    public void DistanceToPoint_PositiveCoordinates_ReturnsCorrectDistance()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(4, 6);

        var result = point1.DistanceToPoint(point2);

        Assert.Equal(5, result, 1);
    }
}
