using System;

namespace Module05.Tasks;

class PointClass(double x, double y)
{
    public double X=x;
    public double Y=y;
}
struct PointStruct
{
    public double X;
    public double Y;

}


public static class Task4
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 4 ---");

        PointStruct struct1 = new() {X=3.14, Y=3.14};
        PointClass class1 = new(3.14, 3.14);

        var struct2 = struct1;
        var class2 = class1;

        struct2.X = 6.28;
        class2.X = 6.28;

        Console.WriteLine(struct1.X);
        Console.WriteLine(class1.X);
    }
}
