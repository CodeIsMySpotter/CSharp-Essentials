using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task11
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 11 ---");
        List<int> IDs = [1, 2, 3, 4];

        var value = IDs.Single();
        Console.WriteLine(value);
    }
}
