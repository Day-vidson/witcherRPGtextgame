namespace WitcherTextRpg.Items;

using WitcherTextRpg.Characters;

public sealed class Weapon : Item
{
    public int Damage { get; private set; }

    public Weapon(int id, string name, int price, int requiredLevel, int damage)
        : base(id, name, price, requiredLevel)
    {
        Damage = damage;
    }

    public override void Use(Player player) => player.Equipment.Equip(this);
    public void Upgrade() => Damage += 3;
}
