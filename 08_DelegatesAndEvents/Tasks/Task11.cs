using System;

namespace Module08.Tasks;

public static class Task11
{

    public static event Action? Action;

    public static void Run()
    {
        Console.WriteLine("--- Zadanie 11 ---");
        Action = () => Console.WriteLine("Line one");
        Action += () => throw new Exception("Mid action exception");
        Action += () => Console.WriteLine("Line to");

        try
        {
            Action();
        }
        
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        

    }
}
