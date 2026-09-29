using System;

namespace Module06.Tasks;

public static class Task1
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 1 ---");
        Console.WriteLine("Enter a number");

        var number = Console.ReadLine();
        if (number is null)
        {
            Console.WriteLine("No number provided");
            return;
        }


        try
        {
            var parsedInt = int.Parse(number);
            Console.WriteLine(parsedInt);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Format");
        }
    }
}
