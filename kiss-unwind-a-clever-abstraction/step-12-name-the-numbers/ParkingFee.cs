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

    public decimal Charge(Ticket t)
    {
        if (t.Minutes <= GraceMinutes) return 0;
        return Math.Min(t.Hours * HourlyRate, DailyCap);
    }
}
