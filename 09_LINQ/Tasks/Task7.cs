using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task7
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 7 ---");
        List<int> numbers = new() { 1, 2, 2, 3, 3, 3, 4 };

        var distincted = numbers.Distinct().ToList();
        Console.WriteLine(string.Join(", ", distincted));
    }
}
