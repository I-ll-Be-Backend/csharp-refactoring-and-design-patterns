using System;

record Booking(DateTime CheckIn, decimal Total, int Nights, char Rate, bool Loyal);
class CancellationPolicy
{
    public decimal Fee(Booking b, DateTime today)
    {
        // days left before check-in
        int d = (b.CheckIn - today).Days;
        // free cancellation 14 days or more before check-in
        if (d >= 14) return 0;
        // non-refundable or under 2 days out: pay in full
        if (b.Rate == 'N' || d < 2) return b.Total;
        // otherwise half the total
        decimal f = b.Total * 0.5m;
        // partner contracts require a one-night minimum
        return Math.Max(f, b.Total / b.Nights);
    }
}
