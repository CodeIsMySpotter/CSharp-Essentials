using System;
using System.Threading;

namespace Module08.Tasks;


class Timer(Action onTick)
{
    public event Action OnTick = onTick;
    public void Start(){
        while (true)
        {
            OnTick?.Invoke();
            Thread.Sleep(250);
        }
    }
}


public static class Task6
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 6 ---");
        Timer timer = new(() => Console.WriteLine("Working"));
        timer.Start();
    }
}
