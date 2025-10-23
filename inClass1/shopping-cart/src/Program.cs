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

        // Resource manager: base name must match the project's root namespace + folder name
        var rm = new ResourceManager("shopping-cart.Localization.Resources", typeof(Program).Assembly);

        // Show the initial language menu in English by default
        var defaultMenuCulture = new CultureInfo("en-US");
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
            _ => new CultureInfo("en-US"),
        };

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        string T(string key) => rm.GetString(key, culture) ?? key;

        // 1) Ask number of items
        int itemCount;
        while (true)
        {
            Console.Write(T("EnterItemCount"));
            var countInput = Console.ReadLine();
            if (int.TryParse(countInput, NumberStyles.Integer, culture, out itemCount) && itemCount >= 0)
                break;
            Console.WriteLine(T("InvalidNumber"));
        }

        var items = new List<(decimal Price, int Quantity)>();

        for (int i = 1; i <= itemCount; i++)
        {
            decimal price;
            while (true)
            {
                Console.Write(string.Format(culture, T("EnterPrice"), i));
                var priceInput = Console.ReadLine();
                if (decimal.TryParse(priceInput, NumberStyles.Number, culture, out price) && price >= 0)
                    break;
                Console.WriteLine(T("InvalidNumber"));
            }

            int quantity;
            while (true)
            {
                Console.Write(string.Format(culture, T("EnterQuantity"), i));
                var qtyInput = Console.ReadLine();
                if (int.TryParse(qtyInput, NumberStyles.Integer, culture, out quantity) && quantity >= 0)
                    break;
                Console.WriteLine(T("InvalidNumber"));
            }

            var itemTotal = price * quantity;
            Console.WriteLine(string.Format(culture, T("ItemTotal"), i, itemTotal.ToString("C", culture)));

            items.Add((price, quantity));
        }

        // Use existing service for cart total
        var total = shopping_cart.Services.PricingService.CalculateTotal(items);

        Console.WriteLine();
        Console.WriteLine(string.Format(culture, T("Total"), total.ToString("C", culture)));
        Console.WriteLine();
        Console.WriteLine(T("Goodbye"));
        Console.ReadLine();
    }
}