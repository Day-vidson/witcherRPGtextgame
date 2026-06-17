namespace WitcherTextRpg.Services;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Items;

public sealed class Shop
{
    private readonly List<Item> _offer = new()
    {
        new Weapon(1, "Stalowy miecz", 35, 1, 8),
        new Armor(2, "Skórzana zbroja", 30, 1, 4),
        new Potion(3, "Jaskółka", 15, 1, "Heal"),
        new MagicItem(4, "Runiczny amulet", 50, 2, 5)
    };

    public IReadOnlyList<Item> Offer => _offer;

    public bool Buy(int itemId, Player player)
    {
        var item = _offer.FirstOrDefault(i => i.Id == itemId);
        if (item is null || player.Level < item.RequiredLevel || !player.SpendGold(item.Price))
            return false;

        player.Inventory.Add(item);
        return true;
    }

    public bool Upgrade(Item item, Player player)
    {
        const int upgradePrice = 25;
        if (!player.SpendGold(upgradePrice)) return false;

        switch (item)
        {
            case Weapon weapon: weapon.Upgrade(); return true;
            case Armor armor: armor.Upgrade(); return true;
            default: return false;
        }
    }
}
