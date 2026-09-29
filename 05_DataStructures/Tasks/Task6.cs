using System;

namespace Module05.Tasks;

record DeliveryDocument6(int Id, string Address, Coordinates Location);


public static class Task6
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 6 ---");
        DeliveryDocument doc1 = new(1, "1", new(3.14, 3.14));
        DeliveryDocument doc2 = doc1 with { Address = "2" };

        Console.WriteLine($"{doc1.Address} {doc2.Address}");
    }
}
