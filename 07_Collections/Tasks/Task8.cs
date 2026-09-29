using System;
using System.Collections.Generic;

namespace Module07.Tasks;


record Product(int Id, string Name, decimal Price);

public static class Task8
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 8 ---");

        List<Product> products = new();

        for (int idx = 0; idx < 5; idx++)
        {

            byte[] name = new byte[5];
            Random.Shared.NextBytes(name);

            products.Add(new(idx, Convert.ToHexString(name), idx * Random.Shared.Next()));
        }


        var max = decimal.MinValue;
        foreach (var product in products)
        {
            if(product.Price > max) max = product.Price;
        }

        Console.WriteLine($"The most expensive product price is: {max}");
    }
}
