using System;

namespace Module08.Tasks;

public delegate int MathOperation(int x, int y);


public static class Task1
{

    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static int Multiply(int x, int y)
    {
        return x * y;
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 1 ---");
        MathOperation op = Add;

        Console.WriteLine(op(3, 2));

        op = Multiply;
        Console.WriteLine(op(3, 2));

    }
}
