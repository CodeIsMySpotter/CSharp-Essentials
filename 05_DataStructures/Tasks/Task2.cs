using System;

namespace Module05.Tasks;


readonly record struct Coordinates(double X, double Y);

public static class Task2
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 2 ---");
        Coordinates coords = new(3.14, 3.14);
        Console.WriteLine(coords.ToString());
    }
}
