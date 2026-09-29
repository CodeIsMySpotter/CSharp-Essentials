using System;
using System.Collections;
using System.Collections.Generic;

namespace Module07.Tasks;

public static class Task7
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 7 ---");
        Stack<string> history = new();

        history.Push("google");
        history.Push("yt");
        history.Push("github");

        history.Pop();
        Console.WriteLine($"Current site: {history.Peek()}");
    }
}
