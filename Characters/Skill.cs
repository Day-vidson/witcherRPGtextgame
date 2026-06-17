namespace WitcherTextRpg.Characters;

public sealed class Skill
{
    public string Name { get; }
    public int RequiredLevel { get; }
    public int BonusValue { get; }

    public Skill(string name, int requiredLevel, int bonusValue)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        BonusValue = bonusValue;
    }

    public void Apply(Player player)
    {
        if (player.Level >= RequiredLevel)
            player.Stats.Increase("strength", BonusValue);
    }
}
