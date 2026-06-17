namespace WitcherTextRpg.Events;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Factories;
using WitcherTextRpg.Services;
using WitcherTextRpg.UI;
using WitcherTextRpg.World;

public sealed class MonsterEncounter : IExplorationEvent
{
    private readonly IEnemyFactory _enemyFactory;
    private readonly CombatService _combatService;
    private readonly IGameUI _ui;
    private readonly Terrain _terrain;

    public MonsterEncounter(IEnemyFactory enemyFactory, CombatService combatService, IGameUI ui, Terrain terrain)
    {
        _enemyFactory = enemyFactory;
        _combatService = combatService;
        _ui = ui;
        _terrain = terrain;
    }

    public void Trigger(Player player)
    {
        var enemy = _enemyFactory.CreateEnemy(_terrain, player.Level);
        _ui.ShowMessage($"Na drodze pojawia się przeciwnik: {enemy.Name}!");
        _combatService.StartFight(player, enemy);
    }
}
