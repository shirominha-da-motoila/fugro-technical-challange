namespace Domain.Utils;

public static class Helpers
{
    public static bool IsBetween(this double value, double value1, double value2)
    {
        var min = Math.Min(value1, value2);
        var max = Math.Max(value1, value2);

        return (value - min) * (max - value) >= 0;
    }
}