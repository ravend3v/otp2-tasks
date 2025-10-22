namespace shopping_cart.Services;

using System.Collections.Generic;

public static class PricingService
{
    public static decimal CalculateTotal(IEnumerable<(decimal Price, int Quantity)> items)
    {
        decimal total = 0;
        foreach (var (price, quantity) in items)
            total += price * quantity;
        return total;
    }
}