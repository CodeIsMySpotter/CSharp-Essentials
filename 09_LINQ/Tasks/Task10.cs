using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task10
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 10 ---");
        List<int> list = [1, 2, 4, 5, 6];

        Func<int, bool> filter = x => x % 3 == 0;
        
        Console.WriteLine(string.Join(", ", list.Where(filter)));
    }
}
