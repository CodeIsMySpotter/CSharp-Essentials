using System;
using System.Collections.Generic;

namespace Module07.Tasks;


enum OrderStatus
{
    New,
    Processing,
    Shipped
}

class Order(OrderStatus status, int id)
{
    public OrderStatus OrderStatus { get; set; } = status;
    public int Id = id;

}

public static class Task9
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 9 ---");

        Dictionary<OrderStatus, List<Order>> orders = new();
        
        for (int idx = 0; idx < 20; idx++)
        {
            var selector = Random.Shared.Next(3);
            var status = selector switch
            {
                0 => OrderStatus.New,
                1 => OrderStatus.Processing,
                2 => OrderStatus.Shipped,
            };

            if (orders.ContainsKey(status))
            {
                var id = Random.Shared.Next();
                orders[status].Add(new(status, id));
            }
            else
            {
                var id = Random.Shared.Next();
                List<Order> orderList = new() {new(status, id)};
                orders.Add(status, orderList);
            }


        }

        foreach (OrderStatus key in orders.Keys)
        {
            var orderIds = orders[key].Select(order => order.Id);
            Console.WriteLine($"Key: {key} | {string.Join(", ", orderIds)}");
        }
    }
}
