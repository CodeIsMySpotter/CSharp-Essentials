using System;

namespace Module06.Tasks;

public static class Task9
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 9 ---");
        string input = "abc";

        if (int.TryParse(input, out var result))
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Failed to parse the input");
        }
    }
}
