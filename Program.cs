using System;

public class Program
{
    public static void Main(string[] args)
    {
        SavingsAccount savings = new SavingsAccount("Jimbo", 500, 0.02m, 3);
        savings.Deposit(200);
        savings.Withdraw(100);
        savings.ApplyInterest();
        savings.Withdraw(50);
        savings.Withdraw(30);
        savings.Withdraw(20);
        savings.GetBalance();
        savings.ShowTransactionHistory();

        Console.WriteLine("-----------------------");

        CheckingAccount checking = new CheckingAccount("Jake", 300, 100, 35);
        checking.Deposit(100);
        checking.Withdraw(450);
        checking.Withdraw(50);
        checking.GetBalance();
    }
}