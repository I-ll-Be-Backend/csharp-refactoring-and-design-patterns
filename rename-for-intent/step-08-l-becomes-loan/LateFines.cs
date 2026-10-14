
record Loan(int DaysOut, bool Student);

class Fees
{
    public decimal Calc(Loan loan)
    {
        int daysLate = loan.DaysOut - 14;
        if (daysLate <= 0)
        {
            return 0m;
        }
        decimal dailyRate = loan.Student ? 0.10m : 0.25m;
        return Math.Min(daysLate * dailyRate, 10m);
    }
}

class ReturnDesk
{
    private readonly Fees fees = new();

    public string Receipt(Loan loan)
    {
        return $"Late fine: ${fees.Calc(loan)}";
    }
}
