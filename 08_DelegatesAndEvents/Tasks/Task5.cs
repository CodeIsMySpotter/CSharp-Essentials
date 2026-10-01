using System;

namespace Module08.Tasks;

public static class Task5
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 5 ---");

        Action<string> logger = (word) => Console.WriteLine(word.ToUpper());
        logger += (word) => Console.WriteLine(word.Length);
        logger += (word) => Console.WriteLine(System.DateTime.Now);

        logger("Message");
    }
}
