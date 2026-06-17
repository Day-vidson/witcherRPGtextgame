namespace WitcherTextRpg.Characters;

using WitcherTextRpg.Items;
using WitcherTextRpg.World;

public sealed class Player : Character
{
    private readonly List<Skill> _skills = new();

    public int Gold { get; private set; }
    public int Experience { get; private set; }
    public int Level { get; private set; }
    public Terrain? CurrentTerrain { get; set; }
    public Inventory Inventory { get; } = new();
    public Equipment Equipment { get; } = new();
    public IReadOnlyList<Skill> Skills => _skills;

    public Player(string name)
        : base(name, 100, 50, new Stats(8, 7, 6, 8, 6))
    {
        Gold = 50;
        Level = 1;
    }

    public void GainExperience(int xp)
    {
        Experience += xp;
        while (Experience >= Level * 100)
        {
            Experience -= Level * 100;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        MaxHealth += 10;
        Health = MaxHealth;
        Stamina += 5;
        Stats.Increase("strength", 1);
        Stats.Increase("endurance", 1);
    }

    public void AddGold(int amount) => Gold += Math.Max(0, amount);

    public bool SpendGold(int amount)
    {
        if (Gold < amount) return false;
        Gold -= amount;
        return true;
    }

    public void AddSkill(Skill skill) => _skills.Add(skill);
}
