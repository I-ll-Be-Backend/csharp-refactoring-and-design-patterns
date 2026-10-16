using System;

record Booking(DateTime CheckIn, decimal Total, int Nights, char Rate, bool Loyal);
class CancellationPolicy
{
    private const int FreeCancellationDays = 14;
    private const int LastMinuteDays = 2;
    private const char NonRefundable = 'N';

    public decimal Fee(Booking b, DateTime today)
    {
        int daysBeforeCheckIn = (b.CheckIn - today).Days;
        if (IsFreeCancellation(daysBeforeCheckIn)) return 0;
        // non-refundable or under 2 days out: pay in full
        if (b.Rate == NonRefundable
            || daysBeforeCheckIn < LastMinuteDays) return b.Total;
        // otherwise half the total
        decimal f = b.Total * 0.5m;
        // partner contracts require a one-night minimum
        return Math.Max(f, b.Total / b.Nights);
    }

    private bool IsFreeCancellation(int days)
    {
        return days >= FreeCancellationDays;
    }
}
