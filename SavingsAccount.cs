using System;

class SavingsAccount : BankAccount
{
    private decimal interestRate;
    private int withdrawalLimit;
    private int withdrawalsThisMonth;

    public SavingsAccount(string owner, decimal initialBalance, decimal interestRate, int withdrawalLimit)
        : base(owner, initialBalance)
    {
        this.interestRate = interestRate;
        this.withdrawalLimit = withdrawalLimit;
        this.withdrawalsThisMonth = 0;
    }    

    public void ApplyInterest()
    {
        decimal interest = Balance * interestRate;
        Balance += interest;
        AddTransaction(interest, "Interest");
        Console.WriteLine($"{Owner} earned {interest:C} in interest. New balance: {Balance:C}");
    }

    public override void Withdraw(decimal amount)
    {
        if (withdrawalsThisMonth < withdrawalLimit)
        {
            base.Withdraw(amount);
            withdrawalsThisMonth++;
        }
        else
        {
            Console.WriteLine($"{Owner} has reached the withdrawal limit for this month");
        }
    }
}