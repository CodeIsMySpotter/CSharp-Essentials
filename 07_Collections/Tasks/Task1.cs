using System;
using System.Collections.Generic;

namespace Module07.Tasks;

public static class Task1
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 1 ---");
        List<int> list = new();

        for (int idx = 1; idx <= 10; idx++)
        {
            list.Add(idx);
        }

        list.Remove(5);
        list.RemoveAt(0);

        Console.WriteLine(string.Join(", ", list));
        
    }
}
