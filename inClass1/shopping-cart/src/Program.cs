namespace shopping_cart;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        // Resource manager using base name from the Localization folder
        var rm = new ResourceManager("shopping-cart.Localization.Resources", typeof(Program).Assembly);

        // Show the initial language menu in Finnish by default
        var defaultMenuCulture = new CultureInfo("fi-FI");
        Console.WriteLine(rm.GetString("LanguageHeader", defaultMenuCulture));
        Console.WriteLine(rm.GetString("LanguageOptions", defaultMenuCulture));
        Console.WriteLine(rm.GetString("ChooseLanguage", defaultMenuCulture));

        var choice = Console.ReadLine()?.Trim();
        CultureInfo culture = choice switch
        {
            "1" => new CultureInfo("en-US"),
            "2" => new CultureInfo("fi-FI"),
            "3" => new CultureInfo("sv-SE"),
            "4" => new CultureInfo("ja-JP"),
            _ => new CultureInfo("fi-FI"),
        };

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        string T(string key) => rm.GetString(key, culture) ?? key;

        var items = new List<(decimal Price, int Quantity)>();
        while (true)
        {
            Console.Write(T("EnterPrice"));
            var priceInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(priceInput))
                break;

            if (!decimal.TryParse(priceInput, NumberStyles.Number, culture, out var price) || price < 0)
            {
                Console.WriteLine(T("InvalidNumber"));
                continue;
            }

            Console.Write(T("EnterQuantity"));
            var quantityInput = Console.ReadLine();
            if (!int.TryParse(quantityInput, NumberStyles.Integer, culture, out var quantity) || quantity < 0)
            {
                Console.WriteLine(T("InvalidNumber"));
                continue;
            }

            items.Add((price, quantity));

            Console.Write(T("AddAnother"));
            var more = Console.ReadLine()?.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(more) && (more.StartsWith("n") || more == "e"))
                break;
            if (string.IsNullOrEmpty(more))
                break;
        }

        decimal total = 0m;
        foreach (var it in items)
            total += it.Price * it.Quantity;

        Console.WriteLine();
        Console.WriteLine(string.Format(culture, T("Total"), total.ToString("C", culture)));
        Console.WriteLine();
        Console.WriteLine(T("Goodbye"));
        Console.ReadLine();
    }
}
