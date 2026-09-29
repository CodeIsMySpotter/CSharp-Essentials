using System;

namespace Module05.Tasks;

public static class Task8
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 8 ---");
        string? status = Console.ReadLine();
        if (status == null)
        {
            Console.WriteLine("No status provided");
            return;
        }
        if (Enum.TryParse<OrderStatus>(status, out OrderStatus convertedStatus))
        {
            Console.WriteLine(convertedStatus);
        }
        else
        {
            Console.WriteLine("Failed to parse order status");
        }
    }
}
