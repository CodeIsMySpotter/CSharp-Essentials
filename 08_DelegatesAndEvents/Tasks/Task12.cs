using System;
using System.Collections.Generic;

namespace Module08.Tasks;

public static class Task12
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 12 ---");

        List<int> list = new();

        for (var idx = 0; idx < 1000; idx++){
            list.Add(idx * Random.Shared.Next(5));
        }
        int sum = 0;
        
        list.ForEach((element) => sum += element);
        Console.WriteLine(sum);
    }
}
