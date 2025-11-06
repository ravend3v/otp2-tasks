using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using bmiCalculator.Data;
using bmiCalculator.Models;
using bmiCalculator.Services;

namespace bmiCalculator.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BmiDbContext _context;
    private readonly ILocalizationService _localizationService;

    public IndexModel(ILogger<IndexModel> logger, BmiDbContext context, ILocalizationService localizationService)
    {
        _logger = logger;
        _context = context;
        _localizationService = localizationService;
    }

    [BindProperty]
    [Required(ErrorMessage = "Weight is required")]
    [Range(1, 1000, ErrorMessage = "Weight must be between 1 and 1000 kg")]
    public double Weight { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Height is required")]
    [Range(50, 300, ErrorMessage = "Height must be between 50 and 300 centimeters")]
    public double Height { get; set; }

    public double? BMI { get; set; }
    public string? BMICategory { get; set; }
    public string CurrentLanguage { get; set; } = "en";
    public Dictionary<string, string> LocalizedStrings { get; set; } = new();

    public async Task OnGetAsync(string? lang)
    {
        if (!string.IsNullOrEmpty(lang) && new[] { "en", "fi", "fa" }.Contains(lang))
        {
            CurrentLanguage = lang;
            HttpContext.Session.SetString("Language", lang);
        }
        else
        {
            CurrentLanguage = HttpContext.Session.GetString("Language") ?? "en";
        }

        LocalizedStrings = await _localizationService.GetAllLocalizedStringsAsync(CurrentLanguage);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        CurrentLanguage = HttpContext.Session.GetString("Language") ?? "en";
        LocalizedStrings = await _localizationService.GetAllLocalizedStringsAsync(CurrentLanguage);

        if (ModelState.IsValid)
        {
            BMI = CalculateBMI(Weight, Height);
            BMICategory = GetBMICategory(BMI.Value);

            // Save to database
            var bmiResult = new BmiResult
            {
                Weight = Weight,
                Height = Height,
                Bmi = BMI.Value,
                Language = CurrentLanguage
            };

            _context.BmiResults.Add(bmiResult);
            await _context.SaveChangesAsync();
        }

        return Page();
    }

    private double CalculateBMI(double weight, double heightInCm)
    {
        double heightInMeters = heightInCm / 100.0;
        return Math.Round(weight / (heightInMeters * heightInMeters), 2);
    }

    private string GetBMICategory(double bmi)
    {
        return bmi switch
        {
            < 18.5 => LocalizedStrings.GetValueOrDefault("underweight", "Underweight"),
            >= 18.5 and < 25 => LocalizedStrings.GetValueOrDefault("normal_weight", "Normal weight"),
            >= 25 and < 30 => LocalizedStrings.GetValueOrDefault("overweight", "Overweight"),
            >= 30 => LocalizedStrings.GetValueOrDefault("obese", "Obese"),
            _ => "Unknown"
        };
    }
}