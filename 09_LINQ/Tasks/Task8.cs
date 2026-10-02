using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task8
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 8 ---");
        List<int> list = new() { 1, 2, 3 };

        var list2 = list.Select(x => x);
        list.Add(4);

        Console.WriteLine(string.Join(", ", list2));
    }
}
