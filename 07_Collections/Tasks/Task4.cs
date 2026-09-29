using System;
using System.Collections.Generic;

namespace Module07.Tasks;

public static class Task4
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 4 ---");
        Console.WriteLine("Enter the sentence");

        var input = Console.ReadLine();
        if (input is null) return;

        Dictionary<char, int> counter = new();

        foreach (char letter in input)
        {
            if (char.IsWhiteSpace(letter)) continue;

            if (counter.TryGetValue(letter, out var count))
            {
                counter[letter] = count + 1;
            }
            else
            {
                counter.Add(letter, 1);
            }
        }

        foreach (char key in counter.Keys)
        {
            
            Console.WriteLine($"Letter: {key} | Count: {counter[key]}");
        }
    }
}
