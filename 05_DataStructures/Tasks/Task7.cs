using System;

namespace Module05.Tasks;


struct Rectangle
{
    public double Width;
    public double Height;

    public Rectangle(double width, double height)
    {

        if(width <= 0 || height <= 0) throw new ArgumentException("Arguments must be positive");
        Width = width;
        Height = height;

    }

    public override string ToString()
    {
        return $"Width: {Width}, Height: {Height}";
    }

}

public static class Task7
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 7 ---");
        Rectangle rect = new(1, 3.14);
        Console.WriteLine(rect.ToString());
    }
}
