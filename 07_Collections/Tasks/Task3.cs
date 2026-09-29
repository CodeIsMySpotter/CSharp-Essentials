using System;
using System.Collections.Generic;

namespace Module07.Tasks;

public static class Task3
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 3 ---");

        Dictionary<string, string> lang = new();
        lang.Add("jablko", "apple");
        lang.Add("samochod", "car");
        lang.Add("samolot", "plane");


        while (true)
        {
            string input = Console.ReadLine();
            if (input is null || input == "q") break;

            if (lang.TryGetValue(input, out var translated))
            {
                Console.WriteLine(translated);
            }
        }
    }
}
