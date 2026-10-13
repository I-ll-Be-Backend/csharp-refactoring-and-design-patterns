record Cart(decimal Subtotal, bool Member);
class Checkout
{
    public decimal ShippingFee(Cart cart)
    {
        decimal freeFrom = cart.Member ? 25m : 50m;
        if (cart.Subtotal >= freeFrom)
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
        decimal limit = cart.Member ? 25m : 50m;
        if (cart.Subtotal < limit)
        {
            decimal missing = limit - cart.Subtotal;
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
