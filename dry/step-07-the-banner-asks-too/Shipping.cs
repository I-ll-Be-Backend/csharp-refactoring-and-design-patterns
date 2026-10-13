record Cart(decimal Subtotal, bool Member);
static class ShippingPolicy
{
    public const decimal FreeFrom = 50m;
    public const decimal Fee = 4.99m;

    public static bool ShipsFree(Cart cart) => cart.Subtotal >= FreeFrom;
}

class Checkout
{
    public decimal ShippingFee(Cart cart)
    {
        if (ShippingPolicy.ShipsFree(cart))
        {
            return 0m;
        }
        return ShippingPolicy.Fee;
    }
}

class CartBanner
{
    public string Message(Cart cart)
    {
        if (!ShippingPolicy.ShipsFree(cart))
        {
            decimal missing = ShippingPolicy.FreeFrom - cart.Subtotal;
            return $"Add ${missing:0.00} to ship free";
        }
        return "Your order ships free";
    }
}

class OrderEmail
{
    public string ShippingLine(Cart cart)
    {
        bool free = cart.Subtotal >= ShippingPolicy.FreeFrom;
        return free ? "Shipping: free" : $"Shipping: ${ShippingPolicy.Fee}";
    }
}
