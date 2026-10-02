using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task2
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 2 ---");
        List<int> list = new();
        for (var idx = 0; idx < 10; idx++)
        {
            list.Add(Random.Shared.Next());
        }


        Console.WriteLine(string.Join(", ", list.OrderBy(e => e)));
        Console.WriteLine(string.Join(", ", list.OrderByDescending(e => e)));
    }
}
