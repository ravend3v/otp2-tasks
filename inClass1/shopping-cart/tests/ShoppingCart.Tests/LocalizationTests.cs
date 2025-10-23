using System.Globalization;
using System.Resources;
using System.Reflection;
using Xunit;

namespace ShoppingCart.Tests;

public class LocalizationTests
{
    [Fact]
    public void ResourceManager_FinnishCulture_ReturnsCorrectTranslations()
    {
        // Arrange
        var assembly = Assembly.LoadFrom("shopping-cart.dll");
        var rm = new ResourceManager("shopping-cart.Localization.Resources", assembly);
        var finnishCulture = new CultureInfo("fi-FI");

        // Act
        var languageHeader = rm.GetString("LanguageHeader", finnishCulture);
        var enterItemCount = rm.GetString("EnterItemCount", finnishCulture);
        var enterPrice = rm.GetString("EnterPrice", finnishCulture);
        var enterQuantity = rm.GetString("EnterQuantity", finnishCulture);
        var invalidNumber = rm.GetString("InvalidNumber", finnishCulture);
        var total = rm.GetString("Total", finnishCulture);
        var goodbye = rm.GetString("Goodbye", finnishCulture);

        // Assert
        Assert.Equal("Valitse kieli / Choose a language / Välj språk / 言語を選択", languageHeader);
        Assert.Equal("Syötä ostettavien tuotteiden määrä:", enterItemCount);
        Assert.Equal("Syötä tuotteen {0} hinta:", enterPrice);
        Assert.Equal("Syötä tuotteen {0} määrä:", enterQuantity);
        Assert.Equal("Virheellinen numero, yritä uudelleen.", invalidNumber);
        Assert.Equal("Kokonaishinta: {0}", total);
        Assert.Equal("Paina Enter lopettaaksesi.", goodbye);
    }

    [Theory]
    [InlineData("en-US", "Enter the number of items to purchase:")]
    [InlineData("fi-FI", "Syötä ostettavien tuotteiden määrä:")]
    [InlineData("sv-SE", "Ange antalet varor att köpa:")]
    [InlineData("ja-JP", "購入する商品の数を入力してください:")]
    public void ResourceManager_DifferentCultures_ReturnsCorrectEnterItemCountTranslation(string cultureCode, string expected)
    {
        // Arrange
        var assembly = Assembly.LoadFrom("shopping-cart.dll");
        var rm = new ResourceManager("shopping-cart.Localization.Resources", assembly);
        var culture = new CultureInfo(cultureCode);

        // Act
        var result = rm.GetString("EnterItemCount", culture);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ResourceManager_FallbackToNeutral_WhenKeyNotFoundInSpecificCulture()
    {
        // Arrange
        var assembly = Assembly.LoadFrom("shopping-cart.dll");
        var rm = new ResourceManager("shopping-cart.Localization.Resources", assembly);
        var nonExistentCulture = new CultureInfo("de-DE"); // German not implemented

        // Act
        var result = rm.GetString("EnterItemCount", nonExistentCulture);

        // Assert - should fallback to neutral resource (English)
        Assert.Equal("Enter the number of items to purchase:", result);
    }
}