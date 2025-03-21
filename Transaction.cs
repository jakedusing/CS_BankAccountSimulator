using System;

class Transaction
{
    public decimal Amount { get; }
    public string Type { get; }
    public DateTime Timestamp { get; }
    public decimal BalanceAfter { get; }

    public Transaction(decimal amount, string type, decimal balanceAfter)
    {
        Amount = amount;
        Type = type;
        Timestamp = DateTime.Now;
        BalanceAfter = balanceAfter;
    }

    public override string ToString()
    {
        return $"{Timestamp}: {Type} of {Amount:C}, Balance After: {BalanceAfter:C}";
    }
}