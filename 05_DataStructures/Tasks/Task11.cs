using System;

namespace Module05.Tasks;

public static class Task11
{

    static (int, int) FindMinMax(int[] array)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (int number in array)
        {
            if (number > max) max = number;
            if (number < min) min = number;
        }

        
        return (min, max);
    }

    public static void Run()
    {
        Console.WriteLine("--- Zadanie 11 ---");
        (var min, var max) = FindMinMax([4, 3, 2, 6, 1, 2, 8]);
        Console.WriteLine($"{min} {max}");
    }
}
