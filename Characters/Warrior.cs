namespace WitcherTextRpg.Characters;

using WitcherTextRpg.Combat;

public sealed class Warrior : Enemy
{
    public Warrior(string name, int level)
        : base(name, level, 70 + level * 10, 45, new Stats(8 + level, 7, 3, 7, 6), 50 + level * 20, 15 + level * 5)
    {
    }

    public override ICombatAction ChooseAction() => Health < MaxHealth / 3 ? new DodgeAction() : new SwordAttack();
}
