using System.ComponentModel.DataAnnotations;

namespace Modules.CalculateOffsetAndStation;

public class CalculateOffsetAndStationInput
{
    [Required]
    public IEnumerable<PointDto> Polyline { get; set; } = new List<PointDto>();

    [Required]
    public PointDto Point { get; set; } = new PointDto();
}