namespace WitcherTextRpg.Items;

public sealed class Equipment
{
    public Weapon? Weapon { get; private set; }
    public Armor? Armor { get; private set; }
    public MagicItem? MagicItem { get; private set; }

    public void Equip(Item item)
    {
        switch (item)
        {
            case Weapon weapon: Weapon = weapon; break;
            case Armor armor: Armor = armor; break;
            case MagicItem magicItem: MagicItem = magicItem; break;
        }
    }

    public int AttackBonus() => (Weapon?.Damage ?? 0) + (MagicItem?.MagicBonus ?? 0);
    public int DefenseBonus() => Armor?.Defense ?? 0;
}
