using System;

namespace Module05.Tasks;


record Employee(string Name, int Salary);

public static class Task15
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 15 ---");
        Employee employee = new("x", 123);
        Console.WriteLine(employee);
    }
}
