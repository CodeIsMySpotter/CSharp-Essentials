using System;

namespace Module05.Tasks;

public static class Task14
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 14 ---");
        double pi = 3.14;
        object opi = pi;


        double dpi = (double)opi;

        Console.WriteLine(dpi.GetType());
    }
}
