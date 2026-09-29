using System;

namespace Module05.Tasks;

record struct Vector(double X, double Y, double Z);


public static class Task12
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 12 ---");
        Vector vect1 = new(1, 2, 3);
        Vector vect2 = new(1, 2, 3);
        Vector vect3 = vect2 with { X = 2 };

        Console.WriteLine(vect1 == vect2);
        Console.WriteLine(vect2 == vect3);
    }
}
