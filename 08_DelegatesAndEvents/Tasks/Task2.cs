using System;

namespace Module08.Tasks;

public static class Task2
{

    public static void RepeatAction(int count, Action<string> action){
        for (var idx = 0; idx < count; idx++)
        {
            action("Line");
        }
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 2 ---");
        Action<string> action = Console.WriteLine;

        RepeatAction(2, action);
    }
}
