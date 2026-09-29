using System;

namespace Module06.Tasks;

public static class Task8
{

    public static void MethodA()
    {
        try
        {
            throw new FileNotFoundException();
        }
        catch (FileNotFoundException ex)
        {
            throw new ApplicationException("An exception occured:", ex);
        }
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 8 ---");
        try
        {
            MethodA();
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.InnerException);
        }

    }

}
