namespace bmiCalculator.Models;

using System.ComponentModel.DataAnnotations;

public class LocalizationString
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Key { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Value { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string Language { get; set; } = string.Empty;
}