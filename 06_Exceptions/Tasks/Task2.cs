using System;

namespace Module06.Tasks;

public static class Task2
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 2 ---");

        int[] numbers = { 1, 2, 3 };
        Console.WriteLine("Enter a number (0-5)");
        var idx = Console.ReadLine();

        if (idx is null)
        {
            Console.WriteLine("No argument provided");
        }

        try
        {
            int parsedIdx = int.Parse(idx);

            var result = 100 / numbers[parsedIdx];
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid argument format");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index is out of range");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }


    }
}
