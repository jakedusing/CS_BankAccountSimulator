using System;
using System.Runtime.InteropServices;

abstract class BankAccount
{
    public int AccountNumber { get; private set;}
    public string Owner { get; }
    protected decimal Balance;
    private List<Transaction> transactionHistory;

    private static int accountCounter = 1000;

    public BankAccount(string owner, decimal initialBalance) 
    {
        AccountNumber = accountCounter++;
        Owner = owner;
        Balance = initialBalance;
        transactionHistory = new List<Transaction>();

        // log the initial balance
        transactionHistory.Add(new Transaction(initialBalance, "Initial Balance", Balance));
    }

    public virtual void Deposit(decimal amount) {
        if (amount > 0)
        {
            Balance += amount;
            transactionHistory.Add(new Transaction(amount, "Deposit", Balance));
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid amount, must be positive.");
        }
    }

    public virtual void Withdraw(decimal amount) 
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            transactionHistory.Add(new Transaction(amount, "Withdrawal", Balance));
            Console.WriteLine($"Withdrew {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    public void GetBalance() 
    {
        string balanceString = Balance < 0 ? $"-${Math.Abs(Balance):0.00}" : $"{Balance:C2}";
        Console.WriteLine($"Current balance: {balanceString}");
    }

    protected void AddTransaction(decimal amount, string type)
    {
        transactionHistory.Add(new Transaction(amount, type, Balance));
    }

    public void ShowTransactionHistory()
    {
        Console.WriteLine($"\nTransaction History for {Owner}:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}