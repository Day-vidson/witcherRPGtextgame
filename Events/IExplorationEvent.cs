namespace WitcherTextRpg.Events;

using WitcherTextRpg.Characters;

public interface IExplorationEvent
{
    void Trigger(Player player);
}
