using System;
using System.Collections.Generic;

namespace Module07.Tasks;


[Flags]
enum Roles
{
    None = 0,
    Read = 1,
    Write = 2,
    Admin = 4
}


public static class Task11
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 11 ---");
        Queue<(string, Roles)> queue = new();
        queue.Enqueue(("Json", Roles.Admin));
        queue.Enqueue(("BackEd", Roles.Write | Roles.Read));
        queue.Enqueue(("FrontEd", Roles.None));

        while (queue.Count > 0)
        {
            (string UserName, Roles UserRoles) = queue.Dequeue();
            Console.WriteLine($"Username: {UserName}");
            Console.WriteLine($"Read: {UserRoles.HasFlag(Roles.Read)}");
            Console.WriteLine($"Write: {UserRoles.HasFlag(Roles.Write)}");
            Console.WriteLine($"Admin: {UserRoles.HasFlag(Roles.Admin)} {Environment.NewLine}");

            
        }
    }
}
