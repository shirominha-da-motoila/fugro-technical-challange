namespace Modules.CalculateOffsetAndStation;

public class CalculateOffsetAndStationInput
{
    public required IEnumerable<(double, double)> Polyline { get; init; }

    public required (double, double) Point { get; init; }
}