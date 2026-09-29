using System;
using System.Collections.Generic;

namespace Module07.Tasks;

public static class Task2
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 2 ---");
        List<string> names = new() { "Json", "BackEd", "FrontEd" };
        
        for (int idx = names.Count-1; idx >= 0 ; idx--)
        {
            names.RemoveAt(idx);
        }

        Console.WriteLine(string.Join(", ", names));
    }
}
