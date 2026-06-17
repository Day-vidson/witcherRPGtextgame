namespace WitcherTextRpg.Items;

using WitcherTextRpg.Characters;

public sealed class Potion : Item
{
    public string Effect { get; }

    public Potion(int id, string name, int price, int requiredLevel, string effect)
        : base(id, name, price, requiredLevel)
    {
        Effect = effect;
    }

    public override void Use(Player player)
    {
        if (Effect == "Heal") player.Heal(30);
        if (Effect == "Strength") player.Stats.Increase("strength", 2);
    }
}
