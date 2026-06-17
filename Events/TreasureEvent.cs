namespace WitcherTextRpg.Events;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Items;
using WitcherTextRpg.UI;

public sealed class TreasureEvent : IExplorationEvent
{
    private readonly IGameUI _ui;

    public TreasureEvent(IGameUI ui)
    {
        _ui = ui;
    }

    public void Trigger(Player player)
    {
        var potion = new Potion(100, "Jaskółka", 20, 1, "Heal");
        player.Inventory.Add(potion);
        player.AddGold(20);
        _ui.ShowMessage("Znaleziono skrzynię: +20 złota oraz eliksir Jaskółka.");
    }
}
