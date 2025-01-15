namespace Modules.CalculateOffsetAndStation;

public class OffSetAndStation
{
    public required double Offset { get; init; }

    public required double Station { get; init; }
}

public class CalculateOffsetsAndStationsOutput
{
    public required IEnumerable<OffSetAndStation> OffsetsAndStations { get; init; }
}