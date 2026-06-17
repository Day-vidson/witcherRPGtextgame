namespace WitcherTextRpg.Factories;

using WitcherTextRpg.Events;
using WitcherTextRpg.World;

public interface IExplorationEventFactory
{
    IExplorationEvent CreateEvent(Terrain terrain, int playerLevel);
}
