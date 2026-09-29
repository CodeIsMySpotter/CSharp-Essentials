using System;
using System.Collections.Generic;

namespace Module07.Tasks;

class AccountNotFoundException : Exception
{
    public AccountNotFoundException(string message) : base(message) { }
    
}



public static class Task10
{


    public static void ProcessLogin()
    {
        Dictionary<string, int> accounts = new();
        accounts.Add("1234", 1234);
        accounts.Add("2345", 2345);
        accounts.Add("3456", 3456);

        Console.WriteLine("Enter your account number");
        var input = Console.ReadLine();

        if(input is null) throw new ArgumentException("No number provided");
        try
        {
            int pin = accounts[input];
            Console.WriteLine(pin);
        }
        catch (KeyNotFoundException)
        {
            throw new AccountNotFoundException("Account does not exist");
        }

    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 10 ---");
        try
        {
            ProcessLogin();
        }
        catch (AccountNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
