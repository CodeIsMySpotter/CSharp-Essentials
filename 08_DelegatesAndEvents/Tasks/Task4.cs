using System;

namespace Module08.Tasks;

public static class Task4
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 4 ---");

        List<string> list = new();
        list.AddRange(["Json", "BackEd", "FrontEd", "Codyseus"]);

        Console.WriteLine(string.Join(", ", list.FindAll(x => x.Length > 4)));
    }
}
