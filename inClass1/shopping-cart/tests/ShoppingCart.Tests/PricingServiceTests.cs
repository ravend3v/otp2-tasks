using System.Collections.Generic;
using shopping_cart.Services;
using Xunit;

namespace ShoppingCart.Tests;

public class PricingServiceTests
{
    [Fact]
    public void CalculateTotal_ReturnsSumOfPriceTimesQuantity()
    {
        var items = new List<(decimal Price, int Quantity)>
        {
            (1.50m, 2),
            (2.00m, 3),
        };

        var total = PricingService.CalculateTotal(items);

        Assert.Equal(1.50m * 2 + 2.00m * 3, total);
    }
}
