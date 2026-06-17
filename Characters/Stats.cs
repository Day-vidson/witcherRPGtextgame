namespace WitcherTextRpg.Characters;

public sealed class Stats
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Intelligence { get; private set; }
    public int Endurance { get; private set; }
    public int Speed { get; private set; }

    public Stats(int strength, int dexterity, int intelligence, int endurance, int speed)
    {
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Endurance = endurance;
        Speed = speed;
    }

    public void Increase(string stat, int value)
    {
        switch (stat.ToLowerInvariant())
        {
            case "strength": Strength += value; break;
            case "dexterity": Dexterity += value; break;
            case "intelligence": Intelligence += value; break;
            case "endurance": Endurance += value; break;
            case "speed": Speed += value; break;
            default: throw new ArgumentException($"Unknown stat: {stat}");
        }
    }
}
