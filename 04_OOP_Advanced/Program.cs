

var game = new GameEngine();
game.Run();



public abstract class Participant
{

    public string Name { get; set; }
    public int AttackDamage { get; set; }
    public int Health { get; set; }
    


    public virtual void Attack(Participant target)
    {
        target.TakeDamage(AttackDamage, false);
    }

    public virtual bool IsAlive()
    {
        return Health > 0;
    }

    public abstract void TakeDamage(int damage, bool ignoreReduction);
}

public interface IMagical
{
    public void CastSpell(Participant target);
}

public class Mage : Participant, IMagical
{
    public int SpellDamage { get; set; }

    public Mage(string name)
    {
        Name = name;
        AttackDamage = 5;
        SpellDamage = 25;
        Health = 100;
    }

    public override void TakeDamage(int damage, bool ignoreReduction)
    {
        Health -= damage;
        if (Health < 0) Health = 0;

        Console.WriteLine($"Participant named: {Name} took damage. Current Health: {Health}");
    }

    public void CastSpell(Participant target)
    {
        target.TakeDamage(SpellDamage, true);
    }
}


public class Warrior : Participant
{


    public int DamageReduction { get; set; }

    public Warrior(string name)
    {
        Name = name;
        DamageReduction = 3;
        AttackDamage = 15;
        Health = 200;
    }

    
    public override void TakeDamage(int damage, bool ignoreReduction)
    {
        if (ignoreReduction)
        {
            Health -= damage;
        }
        else
        {
            Health = Health - damage + DamageReduction;
        }

        if(Health < 0) Health = 0;
        Console.WriteLine($"Participant named: {Name} took damage. Current Health: {Health}");
    }

}


public class GameEngine
{
    Participant[] participants { get; set; }

    public GameEngine()
    {
        participants = new Participant[2];
        participants[0] = new Warrior("TheFallenKing");
        participants[1] = new Mage("TheGhostOfSun");
    }

    public void Run()
    {
        var tour = 0;
        while (CheckAtLeastTwoAlive())
        {
            var opponent = (tour + 1)%participants.Length;
            var participant = participants[tour];
            if(!participant.IsAlive()) continue;

            if (participant is IMagical magical) magical.CastSpell(participants[opponent]);
            else participant.Attack(participants[opponent]);

            tour ++;
            
            if(tour > participants.Length-1) tour = 0;

        }
    }

    private bool CheckAtLeastTwoAlive()
    {
        var IsAlive = 0;
        foreach (var participant in participants)
        {
            if (participant.IsAlive()) IsAlive++;
            if (IsAlive >= 2) break;
        }

        return IsAlive >= 2;
    }
}

