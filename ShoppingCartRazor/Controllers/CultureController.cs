namespace ShoppingCartRazor.Controllers;

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

[Route("culture")]
public class CultureController : Controller
{
    [HttpPost("set")]
    public IActionResult SetLanguage(string culture, string returnUrl = "/")
    {
        // ensure culture string matches one of the supported cultures
        var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cookieValue, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
        return LocalRedirect(returnUrl);
    }
}
