namespace WitcherTextRpg.Combat;

using WitcherTextRpg.Characters;

public sealed class SwordAttack : ICombatAction
{
    public void Execute(Character attacker, Character target)
    {
        var equipmentBonus = attacker is Player player ? player.Equipment.AttackBonus() : 0;
        var defense = target is Player targetPlayer ? targetPlayer.Equipment.DefenseBonus() : 0;
        var damage = Math.Max(1, attacker.Stats.Strength * 2 + equipmentBonus - defense);
        target.TakeDamage(damage);
    }
}
