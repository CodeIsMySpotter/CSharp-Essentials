using System;

namespace Module06.Tasks;


class InsufficientFundsException : Exception { }
class Account(decimal balance)
{
    public decimal Balance=balance;
    public void Transfer(Account target, decimal amount)
    {
        if (amount > 10000) throw new InvalidOperationException();
        if (amount > Balance) throw new InsufficientFundsException();
        Balance -= amount;
        target.Balance += amount;
    }
}


public static class Task10
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 10 ---");
        Account acc1 = new(100000);
        Account acc2 = new(100);

        try
        {
            acc1.Transfer(acc2, 1000);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Fraud detected");
        }
        catch (InsufficientFundsException)
        {
            Console.WriteLine("You don t have enough funds for the transfer");
        }
        finally
        {
            Console.WriteLine("Connection finalized");
        }
    }
}
