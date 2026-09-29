using System;

namespace Module05.Tasks;

public static class Task17
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 17 ---");
        Product[] products = new Product[5];

        for (int idx = 0; idx < 5; idx++)
        {
            products[idx] = new Product(idx, $"Product{idx}");
        }

        foreach (Product prod in products)
        {
            if(prod.Id % 2 == 0) Console.WriteLine(prod);
        }
    }
}
