using System;

namespace Module06.Tasks;

public static class Task3
{

    public static void ReadData()
    {
        try
        {
            throw new InvalidOperationException("Błąd podczas odczytu danych.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Przechwycono błąd w ReadData: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Zwalnianie zasobów operacyjnych...");
        }
    }
    
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 3 ---");
        ReadData();
    }
}
