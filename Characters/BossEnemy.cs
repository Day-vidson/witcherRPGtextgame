namespace WitcherTextRpg.Characters;

using WitcherTextRpg.Combat;

public sealed class BossEnemy : Enemy
{
    public BossEnemy(string name, int level)
        : base(name, level, 130 + level * 15, 70, new Stats(12 + level, 9, 8, 10, 7), 150 + level * 40, 80 + level * 10)
    {
    }

    public override ICombatAction ChooseAction() => Health < MaxHealth / 2 ? new MagicAttack() : new SwordAttack();

    public override void GiveReward(Player player)
    {
        base.GiveReward(player);
        player.AddGold(50);
    }
}
