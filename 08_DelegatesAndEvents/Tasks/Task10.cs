using System;
using System.Collections.Generic;

namespace Module08.Tasks;

public static class Task10
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 10 ---");
        Dictionary<string, Func<double, double, double>> dict = new();
        dict.Add("+", (x, y) => x + y);
        dict.Add("-", (x, y) => x - y);


        Console.WriteLine("Please enter the expression symbol (+ / -)");
        string? op = Console.ReadLine();
        if(op is null) return;

        try
        {
            Console.WriteLine(dict[op](2, 3));
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"Invalid operation provided");
        }
    }
}
