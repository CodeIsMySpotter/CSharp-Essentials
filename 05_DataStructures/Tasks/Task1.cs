using System;

namespace Module05.Tasks;


enum OrderStatus
{
    New,
    InProgress,
    Completed,
    Canceled
}


public static class Task1
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 1 ---");
        Console.WriteLine(string.Join(", ", Enum.GetNames<OrderStatus>()));

    }
}
