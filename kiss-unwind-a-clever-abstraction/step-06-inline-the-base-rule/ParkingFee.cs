using System;
using System.Collections.Generic;

record Ticket(int Minutes, bool Electric)
{
    public int Hours => (Minutes + 59) / 60;
}
class ParkingFee
{
    delegate decimal Rule(Ticket t, decimal fee);

    static readonly Dictionary<string, Rule> Rules = new()
    {
        ["base"] = (t, f) => t.Hours * 3.0m,
        ["cap"] = (t, f) => Math.Min(f, 20.0m),
        ["grace"] = (t, f) => t.Minutes <= 15 ? 0 : f,
    };

    public decimal Fee(Ticket t)
    {
        decimal f = 0;
        f = t.Hours * 3.0m;
        f = Rules["cap"](t, f);
        f = Rules["grace"](t, f);
        return f;
    }

    public decimal Charge(Ticket t)
    {
        return Fee(t);
    }
}
