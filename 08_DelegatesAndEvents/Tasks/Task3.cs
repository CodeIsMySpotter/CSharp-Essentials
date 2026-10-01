using System;

namespace Module08.Tasks;

public static class Task3
{

    public static void TransformList(List<int> list, Func<int, int> func){
        List<int> newList = new();
        foreach (var num in list){
            var x = func(num);
            newList.Add(x);
        }

        Console.WriteLine(string.Join(", ", newList));
    }

    public static void Run()
    {
        Console.WriteLine("--- Zadanie 3 ---");
        Func<int, int> func = (x) => x * x;
        List<int> list = new();
        list.AddRange([1, 2, 3, 4, 5, 6]);
        
        TransformList(list, func);
    }
}
