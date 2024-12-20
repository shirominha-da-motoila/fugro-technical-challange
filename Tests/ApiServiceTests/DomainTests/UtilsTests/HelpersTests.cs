using ApiService.Domain.Utils;

namespace Tests.ApiServiceTests.DomainTests.UtilsTests;

public class HelpersTests
{
    [Fact]
    public void IsBetween_ValueIsBetweenBounds_ReturnsTrue()
    {
        double value = 5;
        double value1 = 3;
        double value2 = 8;

        bool result = value.IsBetween(value1, value2);

        Assert.True(result);
    }

    [Fact]
    public void IsBetween_ValueEqualsValue1_ReturnsTrue()
    {
        double value = 3;
        double value1 = 3;
        double value2 = 8;

        bool result = value.IsBetween(value1, value2);

        Assert.True(result);
    }

    [Fact]
    public void IsBetween_ValueEqualsValue2_ReturnsTrue()
    {
        double value = 8;
        double value1 = 3;
        double value2 = 8;

        bool result = value.IsBetween(value1, value2);

        Assert.True(result);
    }

    [Fact]
    public void IsBetween_ValueOutsideBounds_ReturnsFalse()
    {
        double value = 9;
        double value1 = 3;
        double value2 = 8;

        bool result = value.IsBetween(value1, value2);

        Assert.False(result);
    }

    [Fact]
    public void IsBetween_ValueIsBetweenBoundsReversed_ReturnsTrue()
    {
        double value = 5;
        double value1 = 8;
        double value2 = 3;

        bool result = value.IsBetween(value1, value2);

        Assert.True(result);
    }

    [Fact]
    public void IsBetween_NegativeValueIsBetweenBounds_ReturnsTrue()
    {
        double value = -3;
        double value1 = -5;
        double value2 = 0;

        bool result = value.IsBetween(value1, value2);

        Assert.True(result);
    }

    [Fact]
    public void IsBetween_NegativeValueOutsideBounds_ReturnsFalse()
    {
        double value = -6;
        double value1 = -5;
        double value2 = 0;

        bool result = value.IsBetween(value1, value2);

        Assert.False(result);
    }

    [Fact]
    public void IsBetween_PositiveValueOutsideBounds_ReturnsFalse()
    {
        double value = 6;
        double value1 = -5;
        double value2 = 0;

        bool result = value.IsBetween(value1, value2);

        Assert.False(result);
    }
}
