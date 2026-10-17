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
        ["ev"] = (t, f) => t.Electric ? Math.Max(0, f - 6.0m) : f,
        ["cap"] = (t, f) => Math.Min(f, 20.0m),
        ["grace"] = (t, f) => t.Minutes <= 15 ? 0 : f,
    };

    public decimal Fee(Ticket t, List<string> plan)
    {
        decimal f = 0;
        foreach (string n in plan) f = Rules[n](t, f);
        return f;
    }

    public decimal Charge(Ticket t)
    {
        return Fee(t, ["base", "ev", "cap", "grace"]);
    }
}
