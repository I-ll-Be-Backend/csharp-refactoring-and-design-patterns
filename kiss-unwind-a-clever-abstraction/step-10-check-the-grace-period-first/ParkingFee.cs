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
        if (t.Minutes <= 15) return 0;
        return Math.Min(t.Hours * 3.0m, 20.0m);
    }

    public decimal Charge(Ticket t)
    {
        return Fee(t);
    }
}
