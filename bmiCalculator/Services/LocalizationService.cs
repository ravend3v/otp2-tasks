using Microsoft.EntityFrameworkCore;
using bmiCalculator.Data;

namespace bmiCalculator.Services;

public class LocalizationService : ILocalizationService
{
    private readonly BmiDbContext _context;

    public LocalizationService(BmiDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetLocalizedStringAsync(string key, string language)
    {
        var localizationString = await _context.LocalizationStrings
            .FirstOrDefaultAsync(ls => ls.Key == key && ls.Language == language);

        return localizationString?.Value ?? key;
    }

    public async Task<Dictionary<string, string>> GetAllLocalizedStringsAsync(string language)
    {
        var strings = await _context.LocalizationStrings
            .Where(ls => ls.Language == language)
            .ToDictionaryAsync(ls => ls.Key, ls => ls.Value);

        return strings;
    }
}