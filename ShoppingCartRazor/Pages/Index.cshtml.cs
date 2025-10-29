namespace ShoppingCartRazor.Pages;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCartRazor.Models;
using ShoppingCartRazor.Helpers;
using System.ComponentModel.DataAnnotations;

public class IndexModel : PageModel
{
    // Key to store the cart in the session
    private const string SessionKeyCart = "_Cart";

    [BindProperty]
    public CartItem NewItem { get; set; } = new CartItem();

    // This hosts the list of items currently in the cart
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    // Calculated property will sum the total cost
    public double TotalCost
    {
        get
        {
            return CartItems.Sum(item => item.Subtotal);
        }
    }

    // Page load handler
    public void OnGet()
    {
        CartItems = HttpContext.Session.Get<List<CartItem>>(SessionKeyCart) ?? new List<CartItem>();
    }

    // Form Post Handler: Add Item
    public IActionResult OnPostAddItem()
    {
        // Load the current cart from session
        CartItems = HttpContext.Session.Get<List<CartItem>>(SessionKeyCart) ?? new List<CartItem>();

        // Check if the form data (Price, Quantity) is valid
        if (ModelState.IsValid)
        {
            CartItems.Add(NewItem);

            // Save the updated list back to the session
            HttpContext.Session.Set(SessionKeyCart, CartItems);
        }

        // Reload the page
        return RedirectToPage();
    }

    public IActionResult OnPostClearCart()
    {
        // Clear the session
        HttpContext.Session.Remove(SessionKeyCart);

        // Reload the page
        return RedirectToPage();
    }

}
