namespace bmiCalculator.Services;

public interface ILocalizationService
{
    Task<string> GetLocalizedStringAsync(string key, string language);
    Task<Dictionary<string, string>> GetAllLocalizedStringsAsync(string language);
}