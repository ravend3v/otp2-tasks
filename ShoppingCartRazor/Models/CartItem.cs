namespace ShoppingCartRazor.Models;

using System.ComponentModel.DataAnnotations;

public class CartItem
{
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public double Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    // Calculated property for the subtotal
    public double Subtotal => Price * Quantity;
}