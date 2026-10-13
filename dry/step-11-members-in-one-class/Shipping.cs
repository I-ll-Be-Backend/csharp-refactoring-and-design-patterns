record Cart(decimal Subtotal, bool Member);
static class ShippingPolicy
{
    private const decimal FreeFrom = 50m;
    private const decimal MemberFreeFrom = 25m;
    public const decimal Fee = 4.99m;

    public static bool ShipsFree(Cart cart) =>
        cart.Subtotal >= FreeFromFor(cart);

    public static decimal AmountToFree(Cart cart) =>
        FreeFromFor(cart) - cart.Subtotal;

    private static decimal FreeFromFor(Cart cart) =>
        cart.Member ? MemberFreeFrom : FreeFrom;
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
            decimal missing = ShippingPolicy.AmountToFree(cart);
            return $"Add ${missing:0.00} to ship free";
        }
        return "Your order ships free";
    }
}

class OrderEmail
{
    public string ShippingLine(Cart cart)
    {
        bool free = ShippingPolicy.ShipsFree(cart);
        return free ? "Shipping: free" : $"Shipping: ${ShippingPolicy.Fee}";
    }
}
