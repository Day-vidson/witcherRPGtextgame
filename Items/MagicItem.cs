namespace WitcherTextRpg.Items;

using WitcherTextRpg.Characters;

public sealed class MagicItem : Item
{
    public int MagicBonus { get; }

    public MagicItem(int id, string name, int price, int requiredLevel, int magicBonus)
        : base(id, name, price, requiredLevel)
    {
        MagicBonus = magicBonus;
    }

    public override void Use(Player player) => player.Equipment.Equip(this);
}
