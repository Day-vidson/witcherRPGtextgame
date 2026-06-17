namespace WitcherTextRpg.Combat;

using WitcherTextRpg.Characters;

public sealed class DodgeAction : ICombatAction
{
    public void Execute(Character attacker, Character target)
    {
        attacker.RestoreStamina();
    }
}
