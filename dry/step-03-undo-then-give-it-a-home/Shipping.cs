record Cart(decimal Subtotal, bool Member);
class Checkout
{
    public decimal ShippingFee(Cart cart)
    {
        if (cart.Subtotal >= 50m)
        {
            return 0m;
        }
        return 4.99m;
    }
}

class CartBanner
{
    public string Message(Cart cart)
    {
        if (cart.Subtotal < 50m)
        {
            decimal missing = 50m - cart.Subtotal;
            return $"Add ${missing:0.00} to ship free";
        }
        return "Your order ships free";
    }
}

class OrderEmail
{
    public string ShippingLine(Cart cart)
    {
        bool free = cart.Subtotal >= 50m;
        return free ? "Shipping: free" : "Shipping: $4.99";
    }
}
