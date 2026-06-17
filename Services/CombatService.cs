namespace WitcherTextRpg.Services;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Combat;
using WitcherTextRpg.UI;

public sealed class CombatService
{
    private readonly TurnManager _turnManager = new();
    private readonly RewardService _rewardService = new();
    private readonly IGameUI _ui;

    public CombatService(IGameUI ui)
    {
        _ui = ui;
    }

    public CombatResult StartFight(Player player, Enemy enemy)
    {
        _turnManager.Initialize(player, enemy);
        _ui.ShowMessage($"Rozpoczyna się walka: {player.Name} vs {enemy.Name}");

        while (player.IsAlive() && enemy.IsAlive())
        {
            _ui.ShowCharacter(player);
            _ui.ShowCharacter(enemy);

            var current = _turnManager.NextTurn();
            if (!_turnManager.CanAct(current)) continue;

            if (current == player)
            {
                var action = ChoosePlayerAction(player);
                ExecuteTurn(action, player, enemy);
            }
            else
            {
                var action = enemy.ChooseAction();
                _ui.ShowMessage($"{enemy.Name} wykonuje akcję: {action.GetType().Name}");
                ExecuteTurn(action, enemy, player);
            }
        }

        if (player.IsAlive())
        {
            _ui.ShowMessage($"Pokonano przeciwnika: {enemy.Name}");
            _rewardService.Grant(enemy, player);
            return CombatResult.PlayerWon;
        }

        _ui.ShowMessage("Gracz został pokonany.");
        return CombatResult.EnemyWon;
    }

    public void ExecuteTurn(ICombatAction action, Character attacker, Character target)
    {
        var targetHpBefore = target.Health;
        action.Execute(attacker, target);
        var damage = Math.Max(0, targetHpBefore - target.Health);
        _ui.ShowMessage(damage > 0
            ? $"{attacker.Name} zadaje {damage} obrażeń."
            : $"{attacker.Name} wykonuje akcję pomocniczą.");
    }

    private ICombatAction ChoosePlayerAction(Player player)
    {
        _ui.ShowMessage("Wybierz akcję: 1 - Atak mieczem, 2 - Znak magiczny, 3 - Eliksir, 4 - Odpoczynek/unik");
        return _ui.ReadChoice() switch
        {
            2 => new MagicAttack(),
            3 => new PotionUse(),
            4 => new DodgeAction(),
            _ => new SwordAttack()
        };
    }
}
