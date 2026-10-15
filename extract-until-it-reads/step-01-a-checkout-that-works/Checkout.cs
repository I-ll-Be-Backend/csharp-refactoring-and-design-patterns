using System;
using System.Collections.Generic;
using System.Linq;

record Item(string Name, decimal Price, int Qty);
record Order(List<Item> Items, bool Express, bool Member);
class Checkout
{
    public string Confirm(Order order)
    {
        if (order.Items.Count == 0)
        {
            throw new ArgumentException("No items");
        }
        decimal total = 0;
        foreach (var item in order.Items)
        {
            total += item.Price * item.Qty;
        }
        total += total < 50.0m ? 4.99m : 0;
        total += order.Express ? 7.50m : 0;
        return $"{order.Items.Count} items, ${total:0.00}";
    }
}
