
record Loan(int D, bool F);

class Fees
{
    public decimal Calc(Loan l)
    {
        if (l.D <= 3)
        {
            return 0m;
        }
        int x = l.D - 14;
        if (x <= 0)
        {
            return 0m;
        }
        decimal r = l.F ? 0.10m : 0.25m;
        return Math.Min(x * r, 10m);
    }
}

class ReturnDesk
{
    private readonly Fees fees = new();

    public string Receipt(Loan l)
    {
        return $"Late fine: ${fees.Calc(l)}";
    }
}
