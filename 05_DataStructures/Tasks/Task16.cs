using System;

namespace Module05.Tasks;

public static class Task16
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 16 ---");
        OrderStatus[] orderStatus = { OrderStatus.Canceled, OrderStatus.Completed, OrderStatus.InProgress };

        foreach (OrderStatus status in orderStatus)
        {
            string message = status switch
            {
                OrderStatus.InProgress => "Order is in progress",
                OrderStatus.Completed => "Order has been completed",
                OrderStatus.Canceled => "Order has been cancelled",
                OrderStatus.New => "Order created",
                _ => "Invalid status"
            };

            Console.WriteLine(message);
        }
    }
}
