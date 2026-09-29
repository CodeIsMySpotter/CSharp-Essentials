using System;
using Module05.Tasks;

namespace Module05;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Proszę podać numer zadania jako argument (np. 1, 2, ..., 20).");
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
                case 10: Task10.Run(); break;
                case 11: Task11.Run(); break;
                case 12: Task12.Run(); break;
                case 13: Task13.Run(); break;
                case 14: Task14.Run(); break;
                case 15: Task15.Run(); break;
                case 16: Task16.Run(); break;
                case 17: Task17.Run(); break;
                case 18: Task18.Run(); break;
                case 19: Task19.Run(); break;
                case 20: Task20.Run(); break;
                default: Console.WriteLine($"Zadanie {taskNumber} nie istnieje."); break;
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowy argument. Proszę podać liczbę całkowitą.");
        }
    }
}
