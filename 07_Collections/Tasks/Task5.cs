using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Module07.Tasks;

public static class Task5
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 5 ---");
        HashSet<int> intSet = new();

        while (intSet.Count < 10)
        {
            var number = Random.Shared.Next();
            intSet.Add(number);
        }

        Console.WriteLine(string.Join(", ", intSet));
    }
}
