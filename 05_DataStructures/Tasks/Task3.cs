using System;

namespace Module05.Tasks;


record DeliveryDocument(int Id, string Address, Coordinates Location);


public static class Task3
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 3 ---");
        DeliveryDocument doc1 = new(1, "4", new(3.14, 3.14));
        DeliveryDocument doc2 = new(1, "4", new(3.14, 3.14));

        Console.WriteLine(doc1 == doc2);
    }
}
