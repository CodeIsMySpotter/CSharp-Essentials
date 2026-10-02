using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task3
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 3 ---");
        
        List<int> list = new();

        var try1 = list.FirstOrDefault();
        Console.WriteLine(try1);

        try
        {
            var try2 = list.First();
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
