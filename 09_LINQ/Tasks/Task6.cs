using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task6
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 6 ---");
        List<decimal> salaries = new() { 4500.50m, 6200m, 8100m, 3200m, 9500m, 5100.75m };

        var stats = salaries
            .GroupBy(x => 1)
            .Select(g =>
            new {
                Sum = g.Sum(),
                Max = g.Max(),
                Avg = g.Average(),
            }).First();

        Console.WriteLine($"{stats.Sum} {stats.Max} {stats.Avg}");
    }
}
