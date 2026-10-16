using System;

record Booking(DateTime CheckIn, decimal Total, int Nights, char Rate, bool Loyal);
class CancellationPolicy
{
    private const int FreeCancellationDays = 14;
    private const int LoyaltyFreeDays = 7;
    private const int LastMinuteDays = 2;
    private const char NonRefundable = 'N';

    public decimal Fee(Booking b, DateTime today)
    {
        int daysBeforeCheckIn = (b.CheckIn - today).Days;
        if (IsFreeCancellation(b, daysBeforeCheckIn)) return 0;
        if (PaysInFull(b, daysBeforeCheckIn)) return b.Total;
        decimal halfTotal = b.Total * 0.5m;
        // partner contracts require a one-night minimum
        return Math.Max(halfTotal, NightlyPrice(b));
    }

    private bool IsFreeCancellation(Booking b, int days)
        => b.Loyal ? days >= LoyaltyFreeDays
                   : days >= FreeCancellationDays;

    private bool PaysInFull(Booking b, int days)
        => b.Rate == NonRefundable || days < LastMinuteDays;

    private decimal NightlyPrice(Booking b) => b.Total / b.Nights;
}
