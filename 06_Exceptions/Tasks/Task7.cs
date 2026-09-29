using System;

namespace Module06.Tasks;

public static class Task7
{

    public static void GetCode()
    {
        var code = Console.ReadLine();
        throw new Exception(code);
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 7 ---");
        try
        {
            GetCode();
        }
        catch (Exception ex) when (ex.Message == "404")
        {
            Console.WriteLine("Not Found");
        }
        catch (Exception ex) when (ex.Message == "403")
        {
            Console.WriteLine("Forbidden");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Not supported code: {ex.Message}");
        }
    }
}
