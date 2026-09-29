using System;
using System.Collections;
using System.Collections.Generic;

namespace Module07.Tasks;

public static class Task6
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 6 ---");

        Queue<string> names = new();
        names.Enqueue("Json");
        names.Enqueue("BackEd");
        names.Enqueue("FrontEd");
        names.Enqueue("Codyseus");

        while (names.Count > 0)
        {
            names.TryDequeue(out var current);
            names.TryPeek(out var next);

            if(next is null) next = "Noone waiting";
            Console.WriteLine($"Now: {current} | Next: {next}");
        }
    }
}
