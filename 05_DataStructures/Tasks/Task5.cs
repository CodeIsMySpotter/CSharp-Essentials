using System;

namespace Module05.Tasks;

[Flags]
enum UserPermissions
{
    None=0,
    Read=1,
    Write=2,
    Execute=4
}

public static class Task5
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 5 ---");
        const UserPermissions perms = UserPermissions.Read | UserPermissions.Write;
        Console.WriteLine(perms.HasFlag(UserPermissions.Execute));
    }
}
