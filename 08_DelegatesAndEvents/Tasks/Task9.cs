using System;
using System.Collections.Generic;

namespace Module08.Tasks;



class Order(int id, string category) 
{ 
    public int Id = id;
    public string Category = category;

}

public static class Task9
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 9 ---");
        List<Order> list = new();
        for (var idx = 0; idx < 10; idx++)
        {
            int id = Random.Shared.Next(1000);

            list.Add(new(id, $"cat{idx % 3}"));
        }


        Dictionary<string, List<int>> dict = new();
        Action<Order> populateDict = order =>
        {
            if (!dict.ContainsKey(order.Category))
            {
                dict[order.Category] = new();
            }
            dict[order.Category].Add(order.Id);
        };
        list.ForEach(populateDict);



        foreach (var key in dict.Keys){
            Console.WriteLine($"{key} {string.Join(", ", dict[key])}");
        }
    }
}
