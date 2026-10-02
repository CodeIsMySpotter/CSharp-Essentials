using System;
using System.Linq;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Module09.Tasks;

public static class Task1
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 1 ---");
        List<string> list = new();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (var idx = 0; idx < 10; idx++)
        {
            var len = Random.Shared.Next(2, 8);
            string name = new string(Random.Shared.GetItems<char>(chars, len));
            list.Add(name); 
        }

        var filtered = list
                        .Where(n => n.Length > 5)
                        .Select(n => n.ToUpper());

        foreach (var word in filtered)
        {
            Console.WriteLine(word);
        }
    }
}
