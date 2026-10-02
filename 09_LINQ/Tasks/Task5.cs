using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

public static class Task5
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 5 ---");
        var cities = new[]
        {
            new { Miasto = "Warszawa", Kraj = "Polska" },
            new { Miasto = "Kraków", Kraj = "Polska" },
            new { Miasto = "Berlin", Kraj = "Niemcy" },
            new { Miasto = "Monachium", Kraj = "Niemcy" },
            new { Miasto = "Paryż", Kraj = "Francja" }
        }.ToList();

        cities.GroupBy(x => x.Kraj).ToList().ForEach(gr => Console.WriteLine($"{gr.Key} {gr.Count()}"));
    }
}
