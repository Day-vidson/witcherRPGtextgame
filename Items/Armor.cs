namespace WitcherTextRpg.Items;

using WitcherTextRpg.Characters;

public sealed class Armor : Item
{
    public int Defense { get; private set; }

    public Armor(int id, string name, int price, int requiredLevel, int defense)
        : base(id, name, price, requiredLevel)
    {
        Defense = defense;
    }

    public override void Use(Player player) => player.Equipment.Equip(this);
    public void Upgrade() => Defense += 2;
}
