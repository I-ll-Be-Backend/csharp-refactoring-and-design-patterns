using System;
using System.Collections.Generic;
using System.Linq;

record Item(string Name, decimal Price, int Qty);
record Order(List<Item> Items, bool Express, bool Member);
class Checkout
{
    public string Confirm(Order order)
    {
        RequireItems(order);
        decimal goods = Subtotal(order);
        decimal discount = MemberDiscount(order, goods);
        decimal total = goods - discount + DeliveryFee(order, goods);
        return $"{order.Items.Count} items, ${total:0.00}";
    }

    private void RequireItems(Order order)
    {
        if (order.Items.Count == 0)
        {
            throw new ArgumentException("No items");
        }
    }

    private decimal Subtotal(Order order) =>
        order.Items.Sum(item => item.Price * item.Qty);

    private decimal MemberDiscount(Order order, decimal goods)
    {
        return order.Member ? goods * 0.10m : 0;
    }

    private decimal DeliveryFee(Order order, decimal goods)
    {
        decimal fee = 0;
        fee += goods < 50.0m ? 4.99m : 0;
        fee += order.Express ? 7.50m : 0;
        return fee;
    }
}
