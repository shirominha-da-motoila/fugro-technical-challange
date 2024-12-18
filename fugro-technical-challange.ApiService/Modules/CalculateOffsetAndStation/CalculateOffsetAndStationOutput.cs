namespace Modules.CalculateOffsetAndStation;

public class CalculateOffsetAndStationOutput
{
    public required double Offset { get; init; }

    public required PointDto Station { get; init; }
}