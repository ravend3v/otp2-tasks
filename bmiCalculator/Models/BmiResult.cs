namespace bmiCalculator.Models;

using System.ComponentModel.DataAnnotations;

public class BmiResult
{
    public int Id { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    public double Height { get; set; }

    [Required]
    public double Bmi { get; set; }

    [MaxLength(10)]
    public string? Language { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}