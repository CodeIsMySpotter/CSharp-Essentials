using System;

namespace Module08.Tasks;


public class TemperatureSensor(EventHandler<int>? temperatureAlert)
{
    public event EventHandler<int>? TemperatureAlert = temperatureAlert;

    public void ReadTemperature()
    {
        int temp = Random.Shared.Next(1000);
        if (temp > 1) TemperatureAlert?.Invoke(this, temp);
    }
}

public static class Task7
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 7 ---");
        TemperatureSensor sensor = new((sender, temp) => Console.WriteLine($"{sender} {temp}"));
        sensor.ReadTemperature();
        sensor.ReadTemperature();
    }
}
