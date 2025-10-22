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

    [Fact]
    public void CalculateTotal_SingleItem_CalculatesCorrectly()
    {
        var items = new List<(decimal Price, int Quantity)> { (10.00m, 3) };

        var total = PricingService.CalculateTotal(items);

        Assert.Equal(30.00m, total);
    }

    [Fact]
    public void CalculateTotal_EmptyList_ReturnsZero()
    {
        var items = new List<(decimal Price, int Quantity)>();

        var total = PricingService.CalculateTotal(items);

        Assert.Equal(0m, total);
    }

    [Theory]
    [InlineData(0.0, 5, 0.0)]
    [InlineData(5.0, 0, 0.0)]
    [InlineData(0.0, 0, 0.0)]
    public void CalculateTotal_ZeroPriceOrQuantity_ReturnsZero(decimal price, int qty, decimal expected)
    {
        var items = new List<(decimal Price, int Quantity)> { ((decimal)price, qty) };

        var total = PricingService.CalculateTotal(items);

        Assert.Equal(expected, total);
    }

    [Fact]
    public void CalculateTotal_Precision_IsPreserved()
    {
        var items = new List<(decimal Price, int Quantity)>
        {
            (0.3333m, 3),
            (0.6667m, 3),
        };

        var total = PricingService.CalculateTotal(items);


        Assert.Equal(0.3333m * 3 + 0.6667m * 3, total);
    }

    [Fact]
    public void CalculateTotal_NegativeValues_IncludedInSum()
    {
        var items = new List<(decimal Price, int Quantity)>
        {
            (10.0m, 1),
            (-2.5m, 2),
        };

        var total = PricingService.CalculateTotal(items);

        Assert.Equal(10.0m * 1 + (-2.5m) * 2, total);
    }
}
