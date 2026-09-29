using System;

namespace Module06.Tasks;

public static class Task4
{

    public static void SetAge(int age)
    {
        if(age < 0 || age > 120) throw new ArgumentOutOfRangeException("Age must be positive and less then 120");
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 4 ---");

        try
        {
            SetAge(150);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
