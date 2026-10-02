using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

record User(int Id, string Username);


public static class Task12
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 12 ---");
        List<User> list = new[]
        {
            new User(1, "salf"),
            new User(2, "sbaclwe"),
            new User(3, "sanciolwe")
        }.ToList();


        var dict = list.ToDictionary(x => x.Id, x => x.Username);
        foreach (var key in dict.Keys)
        {
            Console.WriteLine($"{key} {dict[key]}");
        }
    }
}
