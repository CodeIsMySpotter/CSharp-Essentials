using System;

namespace Module05.Tasks;

public static class Task13
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 13 ---");

        var anonymousType = new { Title = "HarryPotter", Year = 1977 };
        Console.WriteLine(anonymousType.ToString());
    }
}
