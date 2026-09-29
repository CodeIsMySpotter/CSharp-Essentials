using System;

namespace Module06.Tasks;


public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string message) : base(message) { }
    public InvalidPasswordException() : base("Password is too short") { }
    public InvalidPasswordException(string message, Exception innerEx) : base(message, innerEx) { }

}

public static class Task5
{
    public static void RegisterUser(string password)
    {
        if(password.Length < 8) throw new InvalidPasswordException();
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 5 ---");
        try
        {
            RegisterUser("Pass123");
        }
        catch (InvalidPasswordException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
