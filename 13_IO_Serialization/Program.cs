using System;
using System.Threading.Tasks;
using Module13.Tasks;

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
                case 1: Task1.Run(); break;
                case 2: Task2.Run(); break;
                case 3: Task3.Run(); break;
                case 4: Task4.Run(); break;
                case 5: Task5.Run(); break;
                case 6: Task6.Run(); break;
                case 7: Task7.Run(); break;
                case 8: Task8.Run(); break;
                case 9: Task9.Run(); break;
                case 10: await Task10.RunAsync(); break;
                case 11: Task11.Run(); break;
                case 12: Task12.Run(); break;
                default: Console.WriteLine("Nie znaleziono zadania o podanym numerze."); break;
            }
        }
    }
}
