using System;

namespace Module05.Tasks;

public static class Task20
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 20 ---");
        (string Name, int Age)[] people = {
            ("Json", 21),
            ("Qwerty", 67),
            ("BackEd", 24)
        };

        foreach ((string, int) person in people)
        {
            if(person.Item2 > 24) Console.WriteLine(person);
        }
    }
}
