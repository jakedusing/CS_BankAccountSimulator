using System;

class CheckingAccount : BankAccount
{
    private decimal overdraftLimit;
    private decimal overdraftFee;

    public CheckingAccount(string owner, decimal initialBalance, decimal overdraftLimit, decimal overdraftFee)
        : base(owner, initialBalance)
    {
        this.overdraftLimit = overdraftLimit;
        this.overdraftFee = overdraftFee;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount > 0 && (Balance - amount >= -overdraftLimit))
        {
            Balance -= amount;

            if (Balance < 0)
            {
                
                Console.WriteLine($"{Owner} went into overdraft! Fee of {overdraftFee:C} applied.");
                Balance = Balance - overdraftFee;
            }
            string balanceString = Balance < 0 ? $"-${Math.Abs(Balance):0.00}" : $"{Balance:C2}";
            Console.WriteLine($"{Owner} withdrew {amount:C}. New balance: {balanceString}.");
        }
        else
        {
            Console.WriteLine($"Overdraft limit reached for {Owner}. Withdrawal denied.");
        }   
    }
}