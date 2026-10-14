
record Loan(int DaysOut, bool Student);

class Fees
{
    private const int LoanDays = 14;
    private const decimal StudentRate = 0.10m;
    private const decimal StandardRate = 0.25m;

    public decimal Calc(Loan loan)
    {
        int daysLate = loan.DaysOut - LoanDays;
        if (daysLate <= 0)
        {
            return 0m;
        }
        decimal dailyRate = loan.Student ? StudentRate : StandardRate;
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
