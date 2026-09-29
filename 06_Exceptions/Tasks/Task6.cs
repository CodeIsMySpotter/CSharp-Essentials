using System;

namespace Module06.Tasks;

public static class Task6
{

    public static void MethodA()
    {
        throw new Exception("Exception MethodA");
    }

    public static void MethodB()
    {
        try
        {
            MethodA();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 6 ---");
        try
        {
            MethodB();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
