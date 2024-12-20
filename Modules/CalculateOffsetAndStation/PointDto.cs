using System.ComponentModel.DataAnnotations;

namespace Modules.CalculateOffsetAndStation;

public class PointDto
{
    [Required]
    public double X { get; set; }

    [Required]
    public double Y { get; set; }
}