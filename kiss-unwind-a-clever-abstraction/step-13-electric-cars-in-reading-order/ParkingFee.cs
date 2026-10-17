using System;
using System.Collections.Generic;

record Ticket(int Minutes, bool Electric)
{
    public int Hours => (Minutes + 59) / 60;
}
class ParkingFee
{
    private const decimal HourlyRate = 3.0m;
    private const decimal DailyCap = 20.0m;
    private const int GraceMinutes = 15;
    private const int EvFreeHours = 2;

    public decimal Charge(Ticket t)
    {
        if (t.Minutes <= GraceMinutes) return 0;
        int hours = t.Hours;
        if (t.Electric) hours = Math.Max(0, hours - EvFreeHours);
        return Math.Min(hours * HourlyRate, DailyCap);
    }
}
