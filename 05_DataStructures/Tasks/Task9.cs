using System;

namespace Module05.Tasks;

record Product(int Id, string Name);


public static class Task9
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 9 ---");
        Product prod = new(1, "x");

        (int id, string name) = prod;
        Console.WriteLine($"{id} {name}");
    }
}
