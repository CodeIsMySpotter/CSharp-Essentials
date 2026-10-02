using System;
using System.Linq;
using System.Collections.Generic;

namespace Module09.Tasks;

record Employee(string Name, string Department, decimal Salary, DateTime HireDate);


public static class Task13
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 13 ---");
        List<Employee> employees = new[]
        {
            new Employee("Json", "IT", 10500, new DateTime(2019, 4, 23)),
            new Employee("Json", "HR", 6700, new DateTime(2021, 4, 23)),
            new Employee("BackEd", "IT", 21800, new DateTime(2023, 4, 23)),
            new Employee("FrontEd", "IT", 20500, new DateTime(2026, 4, 23)),
            new Employee("Codyseus", "IT", 6000, new DateTime(2026, 4, 23)),
            new Employee("Ed", "IT", 6000, new DateTime(205, 4, 23))
        }.ToList();

        var filtered = employees
            .Where(x => x.Department == "IT" && x.Salary >= 10000 && x.HireDate > new DateTime(2020, 1, 1))
            .Select(x => x.Name)
            .ToList();

        filtered.ForEach(x => Console.WriteLine($"{x}"));
    }
}
