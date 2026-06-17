namespace WitcherTextRpg.Items;

using WitcherTextRpg.Characters;

public abstract class Item
{
    public int Id { get; }
    public string Name { get; }
    public int Price { get; }
    public int RequiredLevel { get; }

    protected Item(int id, string name, int price, int requiredLevel)
    {
        Id = id;
        Name = name;
        Price = price;
        RequiredLevel = requiredLevel;
    }

    public abstract void Use(Player player);
}
