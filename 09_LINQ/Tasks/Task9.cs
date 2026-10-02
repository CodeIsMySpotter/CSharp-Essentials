using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Module09.Tasks;

record Product(string Name, decimal Price, bool IsAvailable);


public static class Task9
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 9 ---");
        List<Product> list = new[]
        {
            new Product("x1", 123m, true),
            new Product("x2", 1234.5m, true),
            new Product("x3", 84.31m, false)

        }.ToList();


        var avg = list.Where(x => x.IsAvailable).Average(x => x.Price);
        Console.WriteLine(avg);
    }
}
