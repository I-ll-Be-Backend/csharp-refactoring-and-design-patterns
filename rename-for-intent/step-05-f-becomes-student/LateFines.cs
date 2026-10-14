
record Loan(int DaysOut, bool Student);

class Fees
{
    public decimal Calc(Loan l)
    {
        int x = l.DaysOut - 14;
        if (x <= 0)
        {
            return 0m;
        }
        decimal r = l.Student ? 0.10m : 0.25m;
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
