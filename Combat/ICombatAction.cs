namespace WitcherTextRpg.Combat;

using WitcherTextRpg.Characters;

public interface ICombatAction
{
    void Execute(Character attacker, Character target);
}
