namespace WitcherTextRpg.Characters;

using WitcherTextRpg.Combat;

public sealed class Monster : Enemy
{
    public Monster(string name, int level)
        : base(name, level, 55 + level * 8, 30, new Stats(7 + level, 5, 2, 5, 4), 40 + level * 15, 10 + level * 4)
    {
    }

    public override ICombatAction ChooseAction() => new SwordAttack();
}
