namespace WitcherTextRpg.Combat;

using WitcherTextRpg.Characters;

public sealed class MagicAttack : ICombatAction
{
    public void Execute(Character attacker, Character target)
    {
        var damage = Math.Max(1, attacker.Stats.Intelligence * 3);
        target.TakeDamage(damage);
    }
}
