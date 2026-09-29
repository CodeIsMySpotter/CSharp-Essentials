using System;

namespace Module05.Tasks;

record struct Player(string Name, int Health);


public static class Task18
{
    public static void Run()
    {
        Console.WriteLine("--- Zadanie 18 ---");
        Player player1 = new Player("Codyseus", 100);
        int damage = 15;

        while (player1.Health > 0)
        {
            if (damage < player1.Health)
            {
                player1 = player1 with { Health = player1.Health - damage };
                Console.WriteLine(player1.Health);
            }
            else
            {
                player1 = player1 with {Health = 0};
            }
        }

        Console.WriteLine($"Player: {player1.Name} is dead");
    }
}
