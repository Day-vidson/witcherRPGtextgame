namespace WitcherTextRpg.Factories;

using WitcherTextRpg.Events;
using WitcherTextRpg.Services;
using WitcherTextRpg.UI;
using WitcherTextRpg.World;

public sealed class ExplorationEventFactory : IExplorationEventFactory
{
    private readonly IEnemyFactory _enemyFactory;
    private readonly CombatService _combatService;
    private readonly IGameUI _ui;
    private readonly Random _random = new();

    public ExplorationEventFactory(IEnemyFactory enemyFactory, CombatService combatService, IGameUI ui)
    {
        _enemyFactory = enemyFactory;
        _combatService = combatService;
        _ui = ui;
    }

    public IExplorationEvent CreateEvent(Terrain terrain, int playerLevel)
    {
        var roll = _random.Next(100);

        if (roll < 60)
            return new MonsterEncounter(_enemyFactory, _combatService, _ui, terrain);

        if (roll < 80)
            return new TreasureEvent(_ui);

        return new QuestEvent(new Quest("Kontrakt wiedźmiński", playerLevel, 50, 25), _ui);
    }
}
