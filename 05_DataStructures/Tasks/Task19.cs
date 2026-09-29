using System;

namespace Module05.Tasks;

public static class Task19
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 19 ---");

        UserPermissions[] permsArray = { UserPermissions.Read, UserPermissions.Write, UserPermissions.Execute };
        UserPermissions userPerm = UserPermissions.None;

        foreach (UserPermissions perm in permsArray)
        {
            userPerm |= perm;
        }

        Console.WriteLine($"None: {userPerm.HasFlag(UserPermissions.None)}");
        Console.WriteLine($"Read: {userPerm.HasFlag(UserPermissions.Read)}");
        Console.WriteLine($"Write: {userPerm.HasFlag(UserPermissions.Write)}");
        Console.WriteLine($"Execute: {userPerm.HasFlag(UserPermissions.Execute)}");
    }
}
