using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task4
{

    
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 4 ---");

        List<int> list = new();

        for (var idx = 0; idx < 200; idx++)
        {
            list.Add(Random.Shared.Next(-10, 150));
        }


        var anyNegative = list.Any(x => x < 0);
        var allLessThen100 = list.All(x => x < 100);

        Console.WriteLine($"{anyNegative} {allLessThen100}");
        
    }
}
