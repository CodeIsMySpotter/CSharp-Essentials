using System;

namespace Module08.Tasks;

public static class Task8
{

    public static void EventHandler(object? sender, int number)
    {
        Console.WriteLine($"Sender: {sender?.ToString()} temp: {number}");
    }
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 8 ---");
        TemperatureSensor sensor = new(null);
        sensor.TemperatureAlert += EventHandler;

        sensor.ReadTemperature();

        sensor.TemperatureAlert -= EventHandler;
        sensor.ReadTemperature();

    }
}
