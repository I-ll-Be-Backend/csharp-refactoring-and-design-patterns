using System;
using System.Collections.Generic;

record Ticket(int Minutes, bool Electric)
{
    public int Hours => (Minutes + 59) / 60;
}
class ParkingFee
{
    public decimal Fee(Ticket t)
    {
        decimal f = 0;
        f = t.Hours * 3.0m;
        f = Math.Min(f, 20.0m);
        f = t.Minutes <= 15 ? 0 : f;
        return f;
    }

    public decimal Charge(Ticket t)
    {
        return Fee(t);
    }
}
