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
            Console.WriteLine(" Bank Account System");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Show Account Details");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option");
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
                    Console.Writeline("Invalid choice");
                    break;
            }
        }
    }
    static void CreateAccount(List<BankAccount> accounts, ref int accountNumber)
    {
        
    }
}