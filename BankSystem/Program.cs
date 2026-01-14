using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<BankAccount> accounts = new List<BankAccount>();
        int nextAccountNumber = 1001;

        while (true)
        {
            Console.WriteLine("\n=== Bank Account System ===");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Show Account Details");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateAccount(accounts, ref nextAccountNumber);
                    break;
                case "2":
                    Deposit(accounts);
                    break;
                case "3":
                    Withdraw(accounts);
                    break;
                case "4":
                    ShowAccounts(accounts);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    static void CreateAccount(List<BankAccount> accounts, ref int accountNumber)
    {
        Console.Write("Enter account holder name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Select account type:");
        Console.WriteLine("1. Checking");
        Console.WriteLine("2. Savings");
        string typeChoice = Console.ReadLine();
        BankAccount newAccount;
        switch (typeChoice)
        {
            case "1":
                newAccount = new CheckingAccount(accountNumber, name);
                break;
            case "2":
                newAccount = new SavingsAccount(accountNumber, name);
                break;
            default:
                Console.WriteLine("Invalid account type.");
                return;
        }
        accounts.Add(newAccount);
        Console.WriteLine($"Account created successfully! Account Number: {accountNumber}");
        accountNumber++;
    }
    static void Deposit(List<BankAccount> accounts)
    {
        BankAccount account = FindAccount(accounts);
        if (account == null) return;

        Console.Write("Enter amount to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            account.Deposit(amount);
            Console.WriteLine($"Deposited {amount:C} successfully.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }
    static void Withdraw(List<BankAccount> accounts)
    {
        BankAccount account = FindAccount(accounts);
        if (account == null) return;
        Console.Write("Enter amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"Withdrawn {amount:C} successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }
    static void ShowAccounts(List<BankAccount> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts available.");
            return;
        }
        foreach (BankAccount account in accounts)
        {
            account.ShowInfo();
        }
    }
    static BankAccount FindAccount(List<BankAccount> accounts)
    {
        Console.Write("Enter account number: ");
        if (!int.TryParse(Console.ReadLine(), out int accNumber))
        {
            Console.WriteLine("Invalid account number.");
            return null;
        }
        BankAccount account = accounts.Find(a => a.AccountNumber == accNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
        }
        return account;
    }
}
abstract class BankAccount
{
    public int AccountNumber { get; private set; }
    public string AccountHolder { get; private set; }
    protected double Balance { get; set; }
    public BankAccount(int accountNumber, string accountHolder)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = 0;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
    }
    public virtual bool Withdraw(double amount)
    {
        if (amount > Balance) return false;
        Balance -= amount;
        return true;
    }
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Account #{AccountNumber} | {AccountHolder} | Balance: {Balance:C}");
    }
}
class CheckingAccount : BankAccount
{
    public CheckingAccount(int accountNumber, string accountHolder) : base(accountNumber, accountHolder)
    {
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"[Checking] Account #{AccountNumber} | {AccountHolder} | Balance: {Balance:C}");
    }
}
class SavingsAccount : BankAccount
{
    private double InterestRate = 0.03;
    public SavingsAccount(int accountNumber, string accountHolder) : base(accountNumber, accountHolder)
    {
    }
    public override bool Withdraw(double amount)
    {
        double totalAmount = amount + (amount * InterestRate);
        if (totalAmount > Balance) return false;
        Balance -= totalAmount;
        return true;
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"[Savings] Account #{AccountNumber} | {AccountHolder} | Balance: {Balance:C}");
    }
}
