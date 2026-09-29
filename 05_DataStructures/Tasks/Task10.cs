using System;
using System.Drawing;

namespace Module05.Tasks;

public static class Task10
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 10 ---");
        Coordinates[] CoordArray = new Coordinates[10];
        foreach (Coordinates coord in CoordArray)
        {
            Console.WriteLine(coord.ToString());
        }


        PointClass[] PointArray = new PointClass[10];
        foreach (PointClass point in PointArray)
        {
            //Console.WriteLine($"{point.X} {point.Y}"); null deref
        }
    }
}
