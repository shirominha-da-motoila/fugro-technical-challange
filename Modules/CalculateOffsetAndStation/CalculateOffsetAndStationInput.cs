namespace Modules.CalculateOffsetAndStation;

public class CalculateOffsetAndStationInput
{
    public required IEnumerable<PointDto> Points { get; init; }
}