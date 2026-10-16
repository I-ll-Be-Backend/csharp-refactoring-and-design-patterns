using System;

record Booking(DateTime CheckIn, decimal Total, int Nights, char Rate, bool Loyal);
class CancellationPolicy
{
    private const int FreeCancellationDays = 14;
    private const int LastMinuteDays = 2;

    public decimal Fee(Booking b, DateTime today)
    {
        int daysBeforeCheckIn = (b.CheckIn - today).Days;
        // free cancellation 14 days or more before check-in
        if (daysBeforeCheckIn >= FreeCancellationDays) return 0;
        // non-refundable or under 2 days out: pay in full
        if (b.Rate == 'N'
            || daysBeforeCheckIn < LastMinuteDays) return b.Total;
        // otherwise half the total
        decimal f = b.Total * 0.5m;
        // partner contracts require a one-night minimum
        return Math.Max(f, b.Total / b.Nights);
    }
}
