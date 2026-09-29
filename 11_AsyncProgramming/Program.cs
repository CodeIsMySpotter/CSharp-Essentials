using System;
using Module11.Tasks;
using System.Threading.Tasks;

public class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Brak argumentów. Uruchom program przekazując numer zadania, np. 1");
            return;
        }

        if (int.TryParse(args[0], out int taskNumber))
        {
            switch (taskNumber)
            {   
                case 1: await Task1.RunAsync(); break;
                case 2: await Task2.RunAsync(); break;
                case 3: await Task3.RunAsync(); break;
                case 4: await Task4.RunAsync(); break;
                case 5: await Task5.RunAsync(); break;
                case 6: await Task6.RunAsync(); break;
                case 7: await Task7.RunAsync(); break;
                case 8: await Task8.RunAsync(); break;
                case 9: await Task9.RunAsync(); break;
                case 10: await Task10.RunAsync(); break;
                case 11: await Task11.RunAsync(); break;
                case 12: await Task12.RunAsync(); break;
                default: Console.WriteLine("Nie znaleziono zadania o podanym numerze."); break;
            }
        }
    }
}
