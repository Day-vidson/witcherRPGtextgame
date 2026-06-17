namespace WitcherTextRpg.Combat;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Items;

public sealed class PotionUse : ICombatAction
{
    public void Execute(Character attacker, Character target)
    {
        if (attacker is not Player player) return;

        var potion = player.Inventory.Items.OfType<Potion>().FirstOrDefault();
        if (potion is null) return;

        potion.Use(player);
        player.Inventory.Remove(potion);
    }
}
